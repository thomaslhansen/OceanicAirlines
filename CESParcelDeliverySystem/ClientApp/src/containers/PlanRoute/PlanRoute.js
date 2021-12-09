import React, { useState, useEffect } from 'react';
import SearchBox from '../../components/SearchBox/SearchBox'
import SearchTable from '../../components/SearchTable/SearchTable'
import Grid from '@material-ui/core/Grid';
import ConfirmRoute from '../../components/ConfirmRoute/ConfirmRoute'

export default function PlanRoute() {

  const [selectedDate, setSelectedDate] = useState(new Date('2014-08-18T21:11:54'));
  const [locations, setLocations] = useState();
  const [routes, setRoutes] = useState([]);
  const [selectedRoute, setSelectedRoute] = useState();

  const selectRoute = (route) => {
    const info = JSON.stringify({
      from: document.getElementById("from").value,
      to: document.getElementById("to").value,
      weight: document.getElementById("weight").value,
      height: document.getElementById("height").value,
      lenght: document.getElementById("length").value,
      width: document.getElementById("width").value,
      type: document.getElementById("type").value,
      route: selectedDate,

    })
  }
  const handleDateChange = (date) => {
    setSelectedDate(date);
  };

  const setLocationData = (data) => {
    setLocations(data.map(location => ({title: location.name, id: location.id, value: location.id})))
  }

  useEffect(() => {
    fetch('/locations')
  .then(response => response.json())
  .then(data => setLocationData(data));
  },[]);

  const getRoutes = async (sort) => {
    console.log(locations)
    
    const body = JSON.stringify({
      sort: sort,
      from: document.getElementById("from").value,
      to: document.getElementById("to").value,
      weight: document.getElementById("weight").value,
      height: document.getElementById("height").value,
      lenght: document.getElementById("length").value,
      width: document.getElementById("width").value,
      type: document.getElementById("type").value,
      date: selectedDate,
    })
    console.log(body)
    const rawResponse = await fetch('/planroute', {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: body
    });
    const content = await rawResponse.json();
  }

  return (
    <Grid container
    spacing={4}
    direction="column"
    alignItems="center"
    justifyContent="center"
    style={{ minHeight: '100vh' }}>
    <Grid item style={{ minWidth: '70vw' }}>
    {typeof selectedRoute === 'undefined'
    ? <SearchTable routes={routes} selectRoute={selectRoute}/>
    : <SearchBox locations={locations} selectedDate={selectedDate} handleDateChange={handleDateChange} getRoutes={getRoutes}/>
    }
    </Grid>
    <Grid item style={{ minWidth: '90vw' }}>
    {typeof selectedRoute === 'undefined'
    ? <ConfirmRoute/>
    :<SearchTable routes={routes} selectRoute={selectRoute}/>
    }
    </Grid>
  </Grid>
  );
};