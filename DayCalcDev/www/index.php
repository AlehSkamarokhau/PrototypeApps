<!DOCTYPE html>
<html>
	<head>
		<script src="js/jquery-2.1.4.min.js"></script>
		<script src="js/bootstrap.min.js"></script>
		<script type="text/javascript">
		
			$(document).ready(function() {

				$('#btnCalc').bind('click', function() {
					
					if ($('#txtDate').val() == "")
					{
						$('#alrDate').show();
					}
					else
					{
						$('#alrDate').hide();
						
						var dateTo = $('#txtDate').val();
					
						$.ajax({
							url: 'code/calculatorController.php',
							type: 'post',
							data: { "functionName" : "getCountDaysToDate", "dateTo" :  dateTo },
							success: function(response) {
								
									$('#result').text(response + ' days');
	
									console.log(response);
									
								}
							});
					}
						
				});
				
				$('#btnPublish').bind('click', function() {
					
					if ($('#txtYourName').val() == "")
					{
						$('#alrYourName').show();
					}
					else
					{
						$('#alrYourName').hide();
						
						if ($('#txtYourLuckyDay').val() == "")
						{
							$('#alrYourLuckyDay').show();
						}
						else
						{
							$('#alrYourLuckyDay').hide();
							
							if ($('#txtWhy').val() == "")
							{
								$('#alrWhy').show();
							}
							else
							{
								$('#alrWhy').hide();
								
								var userName = $('#txtYourName').val();
								var userDate = $('#txtYourLuckyDay').val();
								var userDateDescription = $('#txtWhy').val();
								
								$.ajax({
									url: 'code/luckyDayController.php',
									type: 'post',
									data: { "functionName" : "addUserLuckyDay",
											"userName" : userName,
											"luckyDate" : userDate,
											"descriptionDate" : userDateDescription },
									success: function(response) {
										
										console.log(response);
										
									}
								});
							}
						}
					}
					
				});
				
				$('#lnkLuckyDayOtherUsers').bind('click', function() {
					
					$.ajax({
						url: 'code/luckyDayController.php',
						type: 'post',
						data: { "functionName" : "getUsersLuckyDays" },
						success: function(response) {
							
							$('#lstLuckyDayOtherUsers').html(response);
							
							console.log(response);
							
						}
					});
					
				});
				
				$('#btnShowLog').bind('click', function() {
					
					var magicWord = $('#txtMagicWord').val();
					
					$.ajax({						
						url: 'code/logerController.php',
						type: 'post',
						data: { "magicWord" : magicWord },
						success: function(response) {
							
							console.log(response);
							
							if(response == 1)
							{
								$.ajax({									
									url: 'code/logerController.php',
									type: 'post',
									data: { "functionName" : "readLogFile" },
									success: function(response) {

										console.log(response);
										
										$('#logsData').html(response);
										
									}									
								});								
							}
							else
							{
								$('#logsData').text('You input incorrect magic word.');
							}
						}						
					});				
				});
				
			});
		
		</script>
		<link rel="stylesheet" type="text/css" href="css/bootstrap.min.css">
		<link rel="stylesheet" type="text/css" href="css/bootstrap-theme.min.css">
	</head>
	<body>
		<div class="row">
			<div class="col-md-4">
			</div>
			<div class="col-md-4">
			</div>
			<div class="col-md-4">
			</div>
		</div>
		
		<div class="row">
			<div class="col-md-4">
			</div>
			
			<div class="col-md-4">
				<div class="panel panel-primary">
					<div class="panel-heading">
						Days Calculator
					</div>
					<div class="panel-body">
					
						<form>
						
							<div class="form-group">
								
								<div class="alert alert-warning" style="display: none" id="alrDate">
									<strong>Warning!</strong> Date is empty.
								</div>
								<label for="txtDate">Date:</label>
								<input type="text" class="form-control" id="txtDate">
								
							</div>
							
							<div class="btn-group">
							
								<button type="button" class="btn btn-primary" id="btnCalc">Calculate</button>
								
							</div>
						
						</form>
					
					</div>
					<div class="panel-footer">
						
						<div id="result">
						
						</div>
						
					</div>
				</div>
			</div>
			
			<div class="col-md-4">
			</div>
		</div>
		
		<div class="row">
			<div class="col-md-4">
			</div>
			<div class="col-md-4">
			
				<div class="panel-group">
					<div class="panel panel-default">
						<div class="panel-heading">
							<h3 class="panel-title">
								<a data-toggle="collapse" href="#yourLuckyDay">What's your lucky day?</a>
							</h3>
						</div>
						<div id="yourLuckyDay" class="panel-collapse collapse">
							<div class="panel-body">
							
								
								<form>
								
								
									<div class="form-group">
								
										<div class="alert alert-warning" style="display: none" id="alrYourName">
											<strong>Warning!</strong> Your Name is empty.
										</div>
										
										<label for="txtYourName">Your Name:</label>
										<input type="text" class="form-control" id="txtYourName">
								
									</div>
									
									<div class="form-group">
								
										<div class="alert alert-warning" style="display: none" id="alrYourLuckyDay">
											<strong>Warning!</strong> Your Lucky Day is empty.
										</div>
										
										<label for="txtYourLuckyDay">Your Lucky Day:</label>
										<input type="text" class="form-control" id="txtYourLuckyDay">
								
									</div>
									
									<div class="form-group">
								
										<div class="alert alert-warning" style="display: none" id="alrWhy">
											<strong>Warning!</strong> Why? is empty.
										</div>
										
										<label for="txtWhy">Why?:</label>
										<textarea class="form-control" rows="5" id="txtWhy"></textarea>
								
									</div>
								
								
								</form>
								
							
							</div>
							<div class="panel-footer">

								<div class="btn-group">
								
									<button type="button" class="btn btn-default" id="btnPublish">Publish</button>
								
								</div>
								
							</div>
						</div>
					</div>
				</div>
			
			</div>
			<div class="col-md-4">
			</div>
		</div>
		
		<div class="row">
			<div class="col-md-4">
			</div>
			
			<div class="col-md-4">
			
				 <div class="panel-group">
					<div class="panel panel-default">
						<div class="panel-heading">
							<h4 class="panel-title">
								<a data-toggle="collapse" href="#luckyDayOtherUsers" id="lnkLuckyDayOtherUsers">Lucky day other users</a>
							</h4>
						</div>
						
						<div id="luckyDayOtherUsers" class="panel-collapse collapse">
							<div class="panel-body">

								<ul class="list-group" id="lstLuckyDayOtherUsers">

								</ul>
									
							</div>
						</div>
					</div>
				</div>
			</div>
			
			<div class="col-md-4">
			</div>
		</div>
		
		<div class="row">
			<div class="col-md-4">
			</div>
			
			<div class="col-md-4">
			
				 <div class="panel-group">
					<div class="panel panel-info">
						<div class="panel-heading">
							<h4 class="panel-title">
								<a data-toggle="collapse" href="#logs">Logs</a>
							</h4>
						</div>
						
						<div id="logs" class="panel-collapse collapse">
							<div class="panel-body">
							
								<form>
								
									<div class="form-group">
								
										<div class="alert alert-warning" style="display: none" id="alrMagicWord">
											<strong>Warning!</strong> Magic Word is empty.
										</div>
										
										<label for="txtMagicWord">Magic Word:</label>
										<input type="password" class="form-control" id="txtMagicWord">
								
									</div>
									
									<div class="btn-group">
							
										<button type="button" class="btn btn-primary" id="btnShowLog">Show</button>
								
									</div>
									
								</form>
								
							</div>
							
							<div class="panel-footer" id="logsData">
							</div>
							
						</div>
					</div>
				</div>
			</div>
			
			<div class="col-md-4">
			</div>
		</div>
		
	</body>
</html>