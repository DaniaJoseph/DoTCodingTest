Feature: BookAnAppointment


	@UI_Automation
Scenario Outline: Book An Appointment
Given I am Running test  <TestCaseNo>
And I collect the required data to fill the contact details page
	And the user navigates to nab homepage
	Then verify the title of the page
	Given the user navigates to home loans
	When the user clicks on Book an appointment
	And selects the option for Buying a property
	And one applicant option is selected for How many applicants are there
	And selects the option Full or part time employment in the Income page
	And Money saved option is selected for Deposit amount
	And the user enters the suburb
	And user selects the Phone call option
	And the user selects the appointment date and time
	And the user enter the contact details from an excel sheet
	Then verify the appointment details	
	Examples:
	| TestCaseNo |
	| TC#01      |