# Unit Testing Tutorials

This repository contains sample projects with different testing frameworks.
Unit tests in .NET environments usually are implemented with the following three frameworks. Within this sample project I want to highlight their differences applied on different test cases.

Scenarios:

* exception handling: `Assert.Throws<NotImplementedException>(() => _sut.Import());`

* usage of moq
* parametrized tests
* Assert if method called

## xUnit

* Attributes: [Facts]
* SUTs will be created in constructor and a new one will be used for each test case
* tests run in parallel without interfering with each other

## NUnit 
## MSTest
 
