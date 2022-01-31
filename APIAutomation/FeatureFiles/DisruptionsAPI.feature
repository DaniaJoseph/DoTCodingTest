Feature: DisruptionsAPI

@API_Automation

Scenario Outline: Get count of event based on disruption status
Given I call <Disruptions Resource API> with "Get" http request
When I pass the query parameter <Current>
Then I get the response
And the API call is successful with status code OK
And get the count of the events based on <Disruption Status>

Examples: 
| Disruptions Resource API | Current | Disruption Status |
| api/disruptions/         | true    | C                 |          
