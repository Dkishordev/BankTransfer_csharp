@mytag
Scenario Outline:  Sender transfer amount to Receiver
    Given the <Sender> balance is <senderbalance>
    And <Receiver> balance is <receiverbalance>
    And <Sender> has already transfered to <Receiver> <alreadytransferd> on <transferdate>
    When <Sender> transfers <amount> to <Receiver>
    Then transfer should be <status>

    Examples:
    |Sender|senderbalance|Receiver|receiverbalance|alreadytransfered|transfrdate|amount|status |
    |10001 |10000        |10002   |20000          |80000            |2019-05-30 |1000  |Success|
    |10001 |30000        |10002   |20000          |100000           |2019-05-30 |1000  |Failure|
    |10001 |20000        |10002   |10000          |5000             |2019-05-30 |5000  |Success|
    |10001 |30000        |10002   |20000          |5000             |2019-05-30 |-5000 |Failure|
    |10001 |10000        |10002   |20000          |5000             |2019-05-30 |6000  |Failure|
    |10001 |30000        |10002   |20000          |10000            |2019-05-30 |35000 |Failure|