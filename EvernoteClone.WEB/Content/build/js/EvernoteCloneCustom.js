function SweetAlertDailogMessage(type, message, row, url) {
	Swal.fire({
		title: 'İşlem sonucu',
		text: message,
		type: type,
		showCancelButton: false,
		allowOutsideClick: false,
		confirmButtonColor: '#3085d6',
		cancelButtonColor: 'd33',
		confirmButtonText: 'Tamam'
	}).then(function (result) {
		if (result.value) {
			if (row != null) {
				row.remove();
			}
			else {
				window.location = url;
			}
		}
	});
}