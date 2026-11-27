import './App.css'
import './components/DataQualityDashboard'
import DataQualityDashboard from './components/DataQualityDashboard';
import QualityErrorRow from './components/QualityErrorRow';
import RegistratedQualityError from './components/RegistratedQualityError';

const App = () => {
    return (
      DataQualityDashboard(),
      QualityErrorRow(),
      RegistratedQualityError()
  );
};

export default App