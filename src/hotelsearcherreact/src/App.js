import React from 'react';
import HotelSearcher from './components/HotelSearcher/HotelSearcher';
import Navigation from './components/Navigation/Navigation';
import Filter from './components/Filter/Filter';
import './App.css';
import 'react-dates/initialize';
import 'react-dates/lib/css/_datepicker.css';

function App() {
  return (
    <div className="App">
      <Navigation onRouteChange={null} onSignOut={null} isSignedIn={false} />
      <Filter />
      <HotelSearcher />
    </div>
  );
}

export default App;