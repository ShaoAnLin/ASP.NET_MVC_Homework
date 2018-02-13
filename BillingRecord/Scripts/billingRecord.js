
$(function () {
	$("[data-datetimepicker]").datetimepicker({
		timepicker: false,
		format: 'Y-m-d'
	});
	
	$("[data-monthonlydatepicker]").datetimepicker({
		timepicker: false,
		format: 'Y-m'
	});
});
