document.getElementById('searchButton').addEventListener('click', function () {
    const keywords = document.getElementById('keywords').value.toLowerCase();
    let orderDate = document.getElementById('orderDate').value;

    if (orderDate) {
        orderDate = new Date(orderDate).toLocaleDateString('en-GB');  // Format menjadi dd/mm/yyyy
    }

    console.log("keywords :", keywords);
    console.log("date :", orderDate);

    const rows = document.querySelectorAll('table tbody tr');

    rows.forEach(row => {
        const orderNo = row.querySelector('td:nth-child(3)').textContent.toLowerCase();
        const orderDateValue = row.querySelector('td:nth-child(4)').textContent;
        const customerName = row.querySelector('td:nth-child(5)').textContent.toLowerCase();

        const matchesKeywords = orderNo.includes(keywords) || customerName.includes(keywords);
        const matchesOrderDate = orderDate === "" || orderDateValue.startsWith(orderDate);

        if (matchesKeywords && matchesOrderDate) {
            row.classList.remove('d-none');
        } else {
            row.classList.add('d-none');
        }
    });
});
