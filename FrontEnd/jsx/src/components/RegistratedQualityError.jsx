
function RegistratedQualityError({ errors })
{

    console.log('Errors sendt til komponenten:');
    console.log(errors);

    const errorGroupesByMonth = errors.reduce(

        (groups, error) => {

            const date = new Date(error.RegistrationDate);

            const month = date.getMonth() + 1;
            const year = date.getFullYear();

            const groupName = month + ' ' + year;

            if (!groups[groupName]) {
                groups[groupName] = [];
            }

            groups[groupName].push(error);

            return groups;

        },

        {}

    );

    console.log('Resultat af grupperingen:');
    console.log(errorGroupesByMonth);

    return (
    <div>

        <h1>Quality Errors</h1>

        {Object.entries(errorGroupesByMonth).map(
            ([groupName, errorsInGroup]) => (

                <div key={groupName}>

                    <h2>{groupName}</h2>

                    {errorsInGroup.map(error => (

                        <div key={error.Id}>
                            <p>{error.ErrorType}</p>
                            <p>{error.Date}</p>
                        </div>

                    ))}

                </div>

            )
        )}

    </div>
    );

}

export default RegistratedQualityError;
