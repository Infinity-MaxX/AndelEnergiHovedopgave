const errors = [
    {
        Id: 1,
        RegistrationDate: "2026-11-01",
        ErrorSeverity: 1,
        ErrorType: "Manglende kundenummer",
    },
    {
        Id: 2,
        RegistrationDate: "2026-11-10",
        ErrorSeverity: 2,
        ErrorType: "Forkert email",
    },
    {
        Id: 3,
        RegistrationDate: "2026-11-15",
        ErrorSeverity: 3,
        ErrorType: "Dublet kunde",
    },
    {
        Id: 4,
        RegistrationDate: "2026-10-20",
        ErrorSeverity: 1,
        ErrorType: "Manglende telefonnummer",
    },
    {
        Id: 5,
        RegistrationDate: "2026-10-25",
        ErrorSeverity: 2,
        ErrorType: "Forkert postnummer",
    },
    {
        Id: 6,
        RegistrationDate: "2026-09-12",
        ErrorSeverity: 3,
        ErrorType: "Manglende kontrakt",
    }
];

function getSeverityText(severityId)
{
    switch (severityId)
    {
        case 1:
            return 'Low';
        case 2:
            return 'Medium';
        case 3:
            return 'High';
        default:
            return 'Unknown';
    }
}

const errorGroupesByMonth = errors.reduce(
    (groups,error)=>{
        const date = new Date(error.RegistrationDate);

        const month = date.getMonth()+1;
        const year = date.getFullYear();

        const errorGroupe = month + " " + year;
        if(!groups[errorGroupe])
            {
                groups[errorGroupe]=[];
            }
        groups[errorGroupe].push(error);

        return groups
        },
        {}
);
console.log(errorGroupesByMonth);

//Foreach object in the array from ErrorGrupsByMonth, each error is being represented as a divTag, with the nesersarry information
function QualityErrorRow()
{
    return (
        <div>
            <h1>Quality errors</h1>
            {Object.entries(errorGroupesByMonth).map(([groupeName, errorsInGroup]) => (
                <div key={groupeName}>
                    <h2>{groupeName}</h2>
                    {errorsInGroup.map((error) => (
                        <div key={error.Id}>
                            <p>{error.RegistrationDate}</p>
                            <p>{error.ErrorType}</p>
                            <p>Severity: {getSeverityText(error.ErrorSeverity)}</p>
                        </div>
                    ))}
                </div>
            ))}
        </div>
    );
}

export default QualityErrorRow;