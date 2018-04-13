The class ArrivalsNotifier represents the main domain object. In TFL.Service, it´s started as a service with Topshelf. Since teh only goal of that project is to start the physical service, all tests are based on ArrivalsNotifier.

ArrivalsNotifier relies on abstractions, and not implementations, to do their bits of work. This way:

_ ITflReader represents the TFL API retrieval. It´s a fake fixed objects in unit tests time, and a real API call in production code, wittout having to modify ArrivalsNotifier code.

_ IDeviceNotifier represents the interaction with the fake device. SO far, it´s the same i tests and production.

_ ITimedRunner encapsulates a timer. In test time, we can move the time forwads arbitrarily.

ImplementationsProvider represents the Ioc for getting the real implementations. It´s a extremely basic implementation for the purpose of this exercise, without using any Ioc library like Unity or Autofac.

Unit tests relies on fakes for timerunner, tflreader, etc, and it´s supposed to be the main entry point most of the times in develpment time. 

Integration tests check the real implementation of each subcomponent of ArrivalsNotifier. We check, for example, that we´re really able to query the Api, and that the real Timer lets time pass.


On top of this, we could have some end to test testing to verufy the fucntioning of ArrivalsNotifier, as a service, installes in some service. I see it, though, more like a CI thing. Something to run on some Continuos integrations server and not as part of teh development environment.


What´s in, what´s not...


The next step would be to implement the notification on train arrival. I managed to write the test (WhenAtrainArrives -> ArrivalIsNotified), not yet the implementation. The class TestTimedRunner should allow us, in test time, to simulate time passing, and we will checl that a notification is sent to FakeDeviceNotifier. Since we´re still realying in ArrivalsNotifier, it will simulate what happens in production when a train has arrived.

In a similar way we would tests that teh system it able to refresh itself once the current predictions are exhausted.

