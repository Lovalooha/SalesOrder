document.getElementById("addItem").addEventListener("click", function () {
    const tableBody = document.querySelector("#itemsTable tbody");

    const row = document.createElement("tr");

    const noCell = document.createElement("td");
    const actionCell = document.createElement("td");
    const itemNameCell = document.createElement("td");
    const qtyCell = document.createElement("td");
    const priceCell = document.createElement("td");
    const totalCell = document.createElement("td");

    noCell.textContent = tableBody.rows.length + 1;
    itemNameCell.innerHTML = `<input type="text" class="form-control itemName" name="SaveOrder.Items[${tableBody.rows.length}].ITEM_NAME" placeholder="Item Name">`;
    qtyCell.innerHTML = `<input type="number" class="form-control quantity" name="SaveOrder.Items[${tableBody.rows.length}].QUANTITY" value="1" onchange="calculateTotal()">`;
    priceCell.innerHTML = `<input type="number" class="form-control price" name="SaveOrder.Items[${tableBody.rows.length}].PRICE" value="0" onchange="calculateTotal()">`;
    totalCell.textContent = "0.00";

    actionCell.innerHTML = `<button class="btn btn-danger btn-sm" onclick="deleteRow(this)">Delete</button>`;
        
    row.appendChild(noCell);
    row.appendChild(actionCell);
    row.appendChild(itemNameCell);
    row.appendChild(qtyCell);   
    row.appendChild(priceCell);
    row.appendChild(totalCell);

    tableBody.appendChild(row);

    calculateTotal();
});

function calculateTotal() {
    let totalAmount = 0;
    const rows = document.querySelectorAll("#itemsTable tbody tr");
    rows.forEach(row => {
        const qty = parseInt(row.querySelector("td:nth-child(4) input").value);
        const price = parseFloat(row.querySelector("td:nth-child(5) input").value);
        const total = qty * price;
        row.querySelector("td:nth-child(6)").textContent = total.toFixed(2);
        totalAmount += total;
    });
    document.getElementById("totalAmount").textContent = totalAmount.toFixed(2);
    document.getElementById("totalItems").textContent = rows.length;
}

function deleteRow(button) {
    const row = button.closest("tr");
    row.remove();
    calculateTotal();
}


//document.getElementById("saveOrder").addEventListener("click", function () {
//    const orderNo = document.getElementById("salesOrderNo").value;
//    const orderDate = document.getElementById("orderDate").value;
//    const customerId = document.getElementById("customer").value;
//    const address = document.getElementById("address").value;

//    let items = [];
//    document.querySelectorAll("#itemsTable tbody tr").forEach(function (row) {
//        const itemName = row.querySelector(".itemName").value; 
//        const quantity = parseInt(row.querySelector(".quantity").value); 
//        const price = parseFloat(row.querySelector(".price").value);  

//        items.push({
//            itemName: itemName,
//            quantity: quantity,
//            price: price
//        });
//    });

//    fetch("/SalesOrderPage/Create?handler=SaveOrder", {
//        method: 'POST',
//        headers: {
//            'Content-Type': 'application/json'
//        },
//        body: JSON.stringify({
//            orderNo: orderNo,
//            orderDate: orderDate,
//            customerId: customerId,
//            address: address,
//            items: items
//        })
//    })
//        .then(response => response.json())
//        .then(data => {
//            if (data.message === "Order saved successfully") {
//                alert("Order saved successfully!");
//            } else {
//                alert("Failed to save the order.");
//            }
//        })
//        .catch(error => {
//            console.error("Error saving order:", error);
//            alert("There was an error saving the order.");
//        });
//});
