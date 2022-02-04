# README #


### What is this repository for? ###

* This repository contains the coding test for DoT which includes the UI automation using Selenium C# with Data Driven from Specflow framework.
* One solution contains multiple projects for UI automation.

## Pre-requisite: 
Miscrosoft Visual Studio 2019 should be installed in the system.

## Selenium Framework with Specflow
BDD framework for UI automation using Selenium C# and Nunit.

The framework has following features:

- BDD (Specflow) based framework along with Data Driven
- Nunit for assertions
- Utils package to handle webelements
- Centralized Configuration (Using App.config file)
- POM
- Hooks

## Framework and Project folders
- Factory – Initializes the driver.
- Utils – for web elements and few javascript utils.
- Pages – C# classes for different pages to locate the elements and perform actions.
- Features – for adding feature files.
- StepDefinitions – add steps corresponding to the feature file. and hooks class which contains the annotations.
- Hooks - Binding class which contains the annotations fro Before Scenario and After Scenario.

## Execution
Clone the code into your local from the GitHub repository :

**git clone https://github.com/DaniaJoseph/DoTCodingTest.git**

*Option 1*: Build the project and from the test explorer window run the tests.

## Azure Devops Execution
1.Access the Azure project ->https://dev.azure.com/josephd0148/DoTCodingTest
2.Run the Automation build pipeline
3.Create the release for Coding test to run the test.
4.Access the Tests tab in the release logs to view the test results
# DoTCodingTest
