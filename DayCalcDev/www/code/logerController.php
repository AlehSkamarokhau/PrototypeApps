<?
	
	// Constants
	
	define('DB_SERVER_NAME', '127.0.0.1');
	define('DB_USER_NAME', 'root');
	define('DB_USER_PASSWORD', '12345');
	define('DB_SHEMA_NAME', 'daycalc100');
	
	if(isset($_POST['magicWord']))
	{
		logRequests();
		echo checkMagicWord($_POST['magicWord']);
	}
	
	if(isset($_POST['functionName']) & $_POST['functionName'] == 'readLogFile')
	{
		logRequests();
		echo readLogFile();
	}
	
	function checkMagicWord($magicWord) {
		
		if($magicWord !== "")
		{
			$conn = new mysqli(DB_SERVER_NAME, DB_USER_NAME, DB_USER_PASSWORD, DB_SHEMA_NAME);
			
			if ($conn->connect_error)
			{
				die("Connection failed: " . $conn->connect_error);
			}
			
			$sql = "SELECT value_configuration FROM app_configuration WHERE key_configuration = 'MAGIC_WORD'";
			
			$result = mysqli_query($conn, $sql);
			$row = mysqli_fetch_assoc($result);
			
			$dbMagicWord = $row['value_configuration'];
			
			$conn->close();
			
			if($dbMagicWord == $magicWord)
			{
				return 1;
			}
		}
		
		return 0;
	}
	
	function logRequests() {
		
		$fd = fopen("trace.txt", "a");
		
		if(!$fd) 
		{
			exit("File open errror!");
		}
		
		fwrite($fd, "***************************\n");
		fwrite($fd, "\n");
		fwrite($fd, date("D M j G:i:s T Y")."\n");
		fwrite($fd, "\n");
		
		$arrRequestHeaders = array();
		$arrRequestHeaders = getallheaders();
		
		fwrite($fd, "\n");
		fwrite($fd, "HTTP REQUEST HEADERS"."\n");
		fwrite($fd, "\n");
		
		foreach($arrRequestHeaders as $key => $value)
		{
			
			fwrite($fd, "$key".' = '."$value"."\n");
			
		}
		
		$arrRequest = array();
		$arrRequest = $_POST;
		
		fwrite($fd, "\n");
		fwrite($fd, "HTTP REQUEST PARAMS"."\n");
		fwrite($fd, "\n");
		
		foreach($arrRequest as $key => $value)
		{
			
			fwrite($fd, "$key".' = '."$value"."\n");
			
		}
		
		
		fwrite($fd, "\n");
		fwrite($fd, "***************************\n");
		
		
		fclose($fd);
		
	}
	
	function readLogFile() {
		
		$outputStr = "";
		
		$fd = fopen("trace.txt", "r");
		
		if(!fd)
		{
			exit("File open error!");
		}
		
		while(!feof($fd))
		{
			$readStr = fgets($fd);
			$outputStr = $outputStr.$readStr;
			$outputStr = $outputStr."</br>";
		}
		
		fclose($fd);
		
		return $outputStr;
	}

?>