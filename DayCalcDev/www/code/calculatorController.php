<?
	
	include "logerController.php";
	
	if (isset($_POST['functionName']) & $_POST['functionName'] == 'getCountDaysToDate') {
		logRequests();
        echo getCountDaysToDate($_POST['dateTo']);
    }
	
	function getCountDaysToDate($date) {
		
		$nowDate = time();
		$toDate = strtotime($date);

		$dateDiff = abs($nowDate - $toDate);

		return floor($dateDiff / (60 * 60 * 24));
		
	}

?>