//This components sends the data to the RegistratesQualityError
import dataQualityErrors from '../mockdata/DataQualityErrors';
import RegistratedQualityError from './RegistratedQualityError';

function DataQualityDashboard()
{

    return (

        <div>

            <h1>Datakvalitet Resultater</h1>
            <RegistratedQualityError
                errors={dataQualityErrors}
            />

        </div>

    );

}

export default DataQualityDashboard;