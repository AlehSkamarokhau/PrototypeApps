<?
	
	include "logerController.php";
	
	// Constants
	
	define('DB_SERVER_NAME', '127.0.0.1');
	define('DB_USER_NAME', 'root');
	define('DB_USER_PASSWORD', '12345');
	define('DB_SHEMA_NAME', 'daycalc100');
	
	if (isset($_POST['functionName']) & $_POST['functionName'] == 'addUserLuckyDay')
	{
		logRequests();
        echo addUserLuckyDay($_POST['userName'], $_POST['luckyDate'], $_POST['descriptionDate']);
    }
	
	if (isset($_POST['functionName']) & $_POST['functionName'] == 'getUsersLuckyDays')
	{
		logRequests();
		echo getUsersLuckyDays();
    }
	
	function addUserLuckyDay($userName, $luckyDate, $description) {

		if ($userName !== '')
		{
			if ($luckyDate !== '')
			{
				if ($description !== '')
				{
					$conn = new mysqli(DB_SERVER_NAME, DB_USER_NAME, DB_USER_PASSWORD, DB_SHEMA_NAME);
					
					if ($conn->connect_error)
					{
						die("Connection failed: " . $conn->connect_error);
					}
					
					$sql = "INSERT INTO lucky_day (name_user, lucky_date, description) VALUES ('$userName', '$luckyDate', '$description')";

					if (mysqli_query($conn, $sql))
					{
						return "New record created successfully";
					}
					else
					{
						return "Error: " . $sql . "<br>" . mysqli_error($conn);
					}
					
					mysqli_close($conn);
				}
			}
		}
		
	}
	
	function getUsersLuckyDays() {

		$conn = new mysqli(DB_SERVER_NAME, DB_USER_NAME, DB_USER_PASSWORD, DB_SHEMA_NAME);
			
		if ($conn->connect_error)
		{
			die("Connection failed: " . $conn->connect_error);
		}
		
		$sql = "SELECT name_user, lucky_date, description FROM lucky_day";
		
		$result = $conn->query($sql);
		
		$result_html = "";
		
		if ($result->num_rows > 0)
		{
			while($row = $result->fetch_assoc())
			{

				$result_html = $result_html . "<li class='list-group-item'>" . $row['name_user'] . "</br>" . $row['lucky_date'] . "</br>" . $row['description'] . "</li>";
				
			}
		}
		else
		{
			return "0 results";
		}
		
		$conn->close();
		
		return $result_html;
	}

?>