﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MLIDS.UnitTests.lib.DAL
{
    [TestClass]
    public class MongoDAL
    {
        [TestMethod]
        public async Task MongoDAL_NullTestAsync()
        {
            var mongo = new MLIDS.lib.DAL.MongoDAL(new MLIDS.lib.Containers.SettingsItem());

            mongo.Initialize();

            await mongo.GetHostPacketsAsync(null);
        }

        [TestMethod]
        public async Task MongoDAL_StringTestAsync()
        {
            var mongo = new MLIDS.lib.DAL.MongoDAL(new MLIDS.lib.Containers.SettingsItem());

            mongo.Initialize();

            await mongo.GetHostPacketsAsync("test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task MongoDAL_WriteNullTestAsync()
        {
            var mongo = new MLIDS.lib.DAL.MongoDAL(new MLIDS.lib.Containers.SettingsItem());

            await mongo.WritePacketAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task MongoDAL_QueryNullTestAsync()
        {
            var mongo = new MLIDS.lib.DAL.MongoDAL(new MLIDS.lib.Containers.SettingsItem());

            await mongo.QueryPacketsAsync(null);
        }

        [TestMethod]
        public async Task MongoDAL_QueryEmptyTestAsync()
        {
            var mongo = new MLIDS.lib.DAL.MongoDAL(new MLIDS.lib.Containers.SettingsItem());

            mongo.Initialize();

            var result = await mongo.QueryPacketsAsync(a => a.Label);

            Assert.IsTrue(!result.Any());
        }
    }
}