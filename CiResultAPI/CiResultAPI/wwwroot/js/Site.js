$(document).ready(async function () {
    const response = await fetch("/api/results",
        {
            method: "GET",
            headers: { "Accept": "application/json" }
        });
    if (response.ok === true) {
        const results = await response.json();
        let elem = $("#table-data-results");
        results.forEach(result => {
            let row = "<tr>";
            //TODO show important columns
            for (var key in result) {
                if (result.hasOwnProperty(key)) {
                    row += "<td>" + result[key] + "</td>";
                }
            }
            row += "</tr>";
            elem.append(row);
        });
    }

    $(".bttn").click(async function () {
        const response = await fetch("/api/results/SearchByDate/1", {
            method: "GET",
            headers: { "Accept": "application/json" }
        });

        if (response.ok) {
            const result = await response.json();
            alert(result);
        };
    });
});


