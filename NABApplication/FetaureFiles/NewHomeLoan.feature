Feature: NewHomeLoan
#@UI_Automation
#Scenario Outline: Request for return call back service
#	Given the user navigates to nab homepage
#	Then verify the title of the page
#	Given the user navigates to home loans
#	When the user clicks on request to call back service
#	And selects the new home loans service	
#	And select the loan topic as <Buying a new property>
#	And the user fills the form with <ExistingCustomer>,<NabId>,<FirstName>,<LastName>,<State>,<PhoneNumber> and <EmailId>
#	And submits the application
#	Then the application is submitted successfully
#	
#	Examples:
#	| ExistingCustomer | NabId    | FirstName | LastName | State | PhoneNumber | EmailId            |
#	| Yes               | 56328061 | Vidhya    | Venugan  | VIC   | 0444592800  | vidhyav9@gmail.com |
	

	@UI_Automation
Scenario Outline: Book An AppoiGSntment
Given I am Running test  <TestCaseNo>
And I collect the required data to fill the contact details page
	And the user navigates to nab homepage
	Then verify the title of the page
	Given the user navigates to home loans
	When the user clicks on Book an appointment
	#And selects Buying a property
	#And selects the new home loans service	
	#And select the loan topic as <Buying a new property>
	#And the user fills the form with <ExistingCustomer>,<NabId>,<FirstName>,<LastName>,<State>,<PhoneNumber> and <EmailId>
	#And submits the application
	#Then the application is submitted successfully
	#
	Examples:
	| TestCaseNo |
	| TC#01      |