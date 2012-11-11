using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputeMidwest.Entity;
using ComputeMidwest.Model;
using NUnit.Framework;
using PusherRESTDotNet;

namespace ComputeMidwest.Test
{
    [TestFixture]
    class NotifierTest
    {
        private HuntNotifier _notifier;
        private HuntInstance _dummyHuntInstance;

        [SetUp]
        public void Init()
        {
            _notifier = new HuntNotifier(new PusherProvider("31452", "04af48f0bd881f9f9737", "0bbb6f45596775fa5d2d"));
            _dummyHuntInstance = DummyHuntFactory.CreateDummyHuntInstance();
        }

        [Test]
        public void TestNotifyHunterJoined()
        {
            _notifier.NotifyHunterJoined(_dummyHuntInstance.Hunters.First());
        }
    }
}
