Feature: ScenarioOutline
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers



@test @mytag
Scenario Outline:  Sender transfer amount to Receiver
    Given the <Sender> balance is <senderbalance>
    And <Receiver> has balance  <receiverbalance>
    And <Sender> already transferred <alreadytransfered> amount to <Receiver> on "<transferdate>" 
    When <Sender> transfers <amount> to <Receiver>
    Then transfer should be "<status>"
    Examples:
    | Scenario_number | Sender | senderbalance | Receiver | receiverbalance | alreadytransfered | transferdate | amount | status  |
    | 1               | 10001  | 10000         | 10002    | 20000           | 80000             | 2020-05-02   | 1000   | Success |
    | 2               | 10001  | 30000         | 10002    | 20000           | 100000            | 2020-05-02   | 1000   | Failure |
    | 3               | 10001  | 20000         | 10002    | 10000           | 5000              | 2020-05-02   | 5000   | Success |
    | 4               | 10001  | 30000         | 10002    | 20000           | 5000              | 2020-05-02   | -5000  | Failure |
    | 5               | 10001  | 10000         | 10002    | 20000           | 5000              | 2020-05-02   | 6000   | Failure |
    | 6               | 10001  | 30000         | 10002    | 20000           | 10000             | 2020-05-02   | 35000  | Failure |
