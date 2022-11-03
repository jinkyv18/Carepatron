# Carepatron Test

* Refactored the API. Make it Controller API so the routing is much easier.
* Create a Service, Repository and Model folder so the code is easy to maintain.
* Create a DTO for model and another model for entity.
* All fields are required for update.
* All fields are required for create, except for Id. Id is automatically guid generated in every insert.
* Search by first name and last name.
* Added an Event after creation of a client. (If the fixed threshold is reached, an event will be raised)
* It is tested in swagger UI.

It took me 3-4hrs to complete this.
