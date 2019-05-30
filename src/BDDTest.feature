Feature: Balance Transfer
    Sender sends balance to receiver
    
Scenario: Sender account has insufficient balance to transfer to Receiver account
    Given the Sender balance is 40,000
    And the Receiver balance is 30,000
    And there is no transaction made by Sender on that day
    When Sender transfers 50,000 to Receiver’s account
    Then transfer shouldn’t happen
 

Scenario: Sender has crossed maximum limit transfer
    Given the Sender balance is 40,000
    And the Receiver balance is 30,000
    When Sender transfers 10,000 to Receiver’s account
    Then transfer shouldn’t happen

Scenario: Balance transferred already in that day is less than maximum transfer limit.
    Given the Sender balance is 80,000
    And the Receiver balance is 30,000
    And balance transferred by sender on that day is 20,000
    When Sender transfers 40,000 to Receiver’s account
    Then transfer should happen
   

Scenario: Sender sends zero balance or negative balance to Receiver
    Given the Sender balance is 40,000
    And the Receiver balance is 30,000
    And balance transferred by sender on that day is 20,000
    When Sender transfers 0 or -1000 to Receiver’s account
    Then transfer shouldn’t happen
   

Scenario: Sender balance becomes less than minimum after transfer to Receiver
    Given the Sender balance is 10,000
    And the Receiver balance is 10,000
    And balance transferred by sender on that day is 20,000
    When Sender transfers 6000 to Receiver’s account
    Then transfer shouldn’t happen
    

Scenario: Sender successfully transfers balance to Receiver account
    Given the Sender balance is 50,000
    And the Receiver balance is 20,000
    And balance transferred by sender on that day is 20,000
    When Sender transfers 10000 to Receiver’s account
    Then transfer should happen
    