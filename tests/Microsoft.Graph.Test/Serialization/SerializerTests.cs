// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Test.Serialization
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    [TestClass]
    public class SerializerTests
    {
        private Serializer serializer;

        [TestInitialize]
        public void Setup()
        {
            this.serializer = new Serializer();
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void AbstractClassDeserializationFailure()
        {
            var stringToDeserialize = "{\"jsonKey\":\"jsonValue\"}";

            try
            {
                this.serializer.DeserializeObject<AbstractClass>(stringToDeserialize);
            }
            catch (ServiceException exception)
            {
                Assert.IsTrue(exception.IsMatch(GraphErrorCode.GeneralException.ToString()), "Unexpected error code thrown.");
                Assert.AreEqual(
                    string.Format("Unable to create an instance of type {0}.", typeof(AbstractClass).AssemblyQualifiedName),
                    exception.Error.Message,
                    "Unexpected error message thrown.");

                throw;
            }
        }

        [TestMethod]
        public void DeserializeDerivedType()
        {
            var userId = "userId";
            var givenName = "name";

            var stringToDeserialize = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"microsoft.graph.user\", \"givenName\":\"{1}\"}}",
                userId,
                givenName);

            var user = this.serializer.DeserializeObject<DirectoryObject>(stringToDeserialize) as User;

            Assert.IsNotNull(user, "User not correctly deserialized.");
            Assert.AreEqual(userId, user.Id, "Unexpected ID initialized.");
            Assert.AreEqual(givenName, user.GivenName, "Unexpected given name initialized.");
        }

        [TestMethod]
        public void DeserializeInvalidODataType()
        {
            var directoryObjectId = "directoryObjectId";
            var givenName = "name";

            var stringToDeserialize = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"invalid\", \"givenName\":\"{1}\"}}",
                directoryObjectId,
                givenName);

            var directoryObject = this.serializer.DeserializeObject<DirectoryObject>(stringToDeserialize);

            Assert.IsNotNull(directoryObject, "Directory object not correctly deserialized.");
            Assert.AreEqual(directoryObjectId, directoryObject.Id, "Unexpected ID initialized.");
            Assert.IsNotNull(directoryObject.AdditionalData, "Additional data not initialized.");
            Assert.AreEqual(givenName, directoryObject.AdditionalData["givenName"] as string, "Unexpected additional data initialized.");
        }

        [TestMethod]
        public void DeserializeStream()
        {
            var attachmentId = "attachmentId";

            var stringToDeserialize = string.Format("{{\"id\":\"{0}\"}}", attachmentId);

            using (var serializedStream = new MemoryStream(Encoding.UTF8.GetBytes(stringToDeserialize)))
            {
                var attachment = this.serializer.DeserializeObject<Attachment>(serializedStream);

                Assert.IsNotNull(attachment, "Attachment not correctly deserialized.");
                Assert.AreEqual(attachmentId, attachment.Id, "Unexpected ID initialized.");
                Assert.IsNull(attachment.AdditionalData, "Unexpected additional data initialized.");
            }
        }

        [TestMethod]
        public void DeserializeUnknownEnumValue()
        {
            var enumValue = "newValue";
            var bodyContent = "bodyContent";

            var stringToDeserialize = string.Format(
                "{{\"contentType\":\"{1}\",\"content\":\"{0}\"}}",
                bodyContent,
                enumValue);

            var itemBody = this.serializer.DeserializeObject<ItemBody>(stringToDeserialize);

            Assert.IsNotNull(itemBody, "Item body not correctly deserialized.");
            Assert.AreEqual(bodyContent, itemBody.Content, "Unexpected body content initialized.");
            Assert.IsNull(itemBody.ContentType, "Unexpected content type initialized.");
            Assert.IsNotNull(itemBody.AdditionalData, "Additional data not initialized.");
            Assert.AreEqual(enumValue, itemBody.AdditionalData["contentType"] as string, "Content type not set in additional data.");
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void DerivedTypeWithoutDefaultConstructor()
        {
            var stringToDeserialize = "{\"jsonKey\":\"jsonValue\"}";

            try
            {
                this.serializer.DeserializeObject<NoDefaultConstructor>(stringToDeserialize);
            }
            catch (ServiceException exception)
            {
                Assert.IsTrue(exception.IsMatch(GraphErrorCode.GeneralException.ToString()), "Unexpected error code thrown.");
                Assert.AreEqual(
                    string.Format("Unable to create an instance of type {0}.", typeof(NoDefaultConstructor).AssemblyQualifiedName),
                    exception.Error.Message,
                    "Unexpected error message thrown.");

                throw;
            }
        }

        [TestMethod]
        public void DeserializeInterface()
        {
            var driveItemChildrenCollectionPage = new DriveItemChildrenCollectionPage
            {
                new DriveItem { Id = "id" },
            };

            var serializedString = this.serializer.SerializeObject(driveItemChildrenCollectionPage);

            var deserializedPage = this.serializer.DeserializeObject<IDriveItemChildrenCollectionPage>(serializedString);

            Assert.IsInstanceOfType(deserializedPage, typeof(DriveItemChildrenCollectionPage), "Unexpected object deserialized.");
            Assert.AreEqual(1, deserializedPage.Count, "Unexpected driveItems deserialized.");
            Assert.AreEqual("id", deserializedPage[0].Id, "Unexpected driveItem deserialized.");
        }

        [TestMethod]
        public void NewAbstractEntityDerivedClassInstance()
        {
            var entityId = "entityId";
            var additionalKey = "key";
            var additionalValue = "value";

            var stringToDeserialize = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"newentity\", \"{1}\":\"{2}\"}}",
                entityId,
                additionalKey,
                additionalValue);

            var entity = this.serializer.DeserializeObject<Entity>(stringToDeserialize);

            Assert.IsNotNull(entity, "Entity not correctly deserialized.");
            Assert.AreEqual(entityId, entity.Id, "Unexpected ID initialized.");
            Assert.IsNotNull(entity.AdditionalData, "Additional data not initialized.");
            Assert.AreEqual(additionalValue, entity.AdditionalData[additionalKey] as string, "Unexpected additional data initialized.");
        }

        [TestMethod]
        public void SerializeAndDeserializeKnownEnumValue()
        {
            var itemBody = new ItemBody
            {
                Content = "bodyContent",
                ContentType = BodyType.Text,
            };

            var expectedSerializedStream = string.Format(
                "{{\"contentType\":\"{1}\",\"content\":\"{0}\"}}",
                itemBody.Content,
                "text");

            var serializedValue = this.serializer.SerializeObject(itemBody);

            Assert.AreEqual(expectedSerializedStream, serializedValue, "Unexpected value serialized.");

            var newItemBody = this.serializer.DeserializeObject<ItemBody>(serializedValue);

            Assert.IsNotNull(newItemBody, "Item body not correctly deserialized.");
            Assert.AreEqual(itemBody.Content, itemBody.Content, "Unexpected body content initialized.");
            Assert.AreEqual(BodyType.Text, itemBody.ContentType, "Unexpected content type initialized.");
            Assert.IsNull(itemBody.AdditionalData, "Additional data initialized.");
        }
    }
}
