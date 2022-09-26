### Refactorings
- Reorganised code to clean architecture pattern
- Added interfaces for the data stores
- Added interfaces for validators
- Added interfaces for data store factory
- Added extension methods to validate MailContainer properties
- Added unit tests for validator
- Added unit tests for factory
- Added unit test for MailContainer validators
- Added dependency injection for all dependencies

### Issues and suggested changes
- AllowedMailTypes using bit based comparison, SmallParcel allows for Large and Standard Letter, this is a bug as per requirements
- Suggestion to create classes for the mail types instead of enums and apply DDD state validation to the classes, alternatively add validator for each of the mail types
- Validation seems to be done on the source container only not the destination container, this is a bug as per requirements

### Mail Container Test 

The code for this exercise has been developed to manage the transfer of mail items from one container to another for processing.

#### Process for transferring mail

- Lookup the container the mail is being transferred from.
- Check the containers are in a valid state for the transfer to take place.
- Reduce the container capacity on the source container and increase the destination container capacity by the same amount.

#### Restrictions

- A container can only hold one type of mail.


#### Assumptions

- For the sake of simplicity, we can assume the containers have an unlimited capacity.

### The exercise brief

The exercise is to take the code in the solution and refactor it into a more suitable approach with the following things in mind:

- Testability
- Readability
- SOLID principles
- Architectural design of the code

You should not change the method signature of the MakeMailTransfer method.

You should add suitable tests into the MailContainerTest.Test project.

There are no additional constraints, use the packages and approach you feel appropriate, aim to spend no more than 2 hours. Please update the readme with specific comments on any areas that are unfinished and what you would cover given more time.

