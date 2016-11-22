#Electronic-Device Claims Center

* user is essentially filling out a form with a decisioning tree
* All decisions can be manually overridden
* Policy data will come from external source
* Multiple-types of question answers
	* Yes-No
	* Multi-select
	* Drop-down
	* Ranges
	* Free text
		* requires an 'underwriter' to get involved

**Requrements**

##### General
1. the user registers and logs in. 
	* email address must be unique
1. Device records from external system are matched on user's email address. The email address tells the system what devices are being used.
1. If email address for registerd user does not match a device, they can register and login anyway, but will be unable to create a claim. Future loaded devices will match on load.
1. The users starts a claim from the list of devices on their policy.
1. Once a claim is began, they are taken through the **claims wizard**.
1. A user can always view a claim status in the application.
1. The user can also call and the claim be taken by a representative in an **internal user claims interface**. In this case, the user is not required to register and authenticate.
	*	The user can still register at any time in the process and see the status of their claim.
1. The claim is not evaluated until the claims wizard is completed.
1. Accounts that are past due at the time of claims origination, are not eligible to start a claim.

##### Claims Wizard
1. Only questions are displayed that are related to the type of failure/damage of the device.

##### Internal User Claims Interface
* All of the questions are displayed at once
* Decisioning indicators are shown

##### Rules
* Water damage is an uncovered claim
* The device is uncovered if they were not the user that damaged the device
* Damage that occurred out of the country is not covered.
* 

###### Questions
1. What is the nature of the claim?
	* Physical damage
	* Physical malfunction
	* Software malfunction
	* Screen cracked
	* Device stolen
1. Is the device water damaged?
1. Is the device usable?
1. Were you using the device when it failed/was damaged?
1. How long 