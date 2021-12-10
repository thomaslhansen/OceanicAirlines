import React, { useState, useEffect } from 'react';
import SearchBox from '../../components/SearchBox/SearchBox'
import SearchTable from '../../components/SearchTable/SearchTable'
import Grid from '@material-ui/core/Grid';
import ConfirmRoute from '../../components/ConfirmRoute/ConfirmRoute'

export default function PlanRoute() {

  const [selectedDate, setSelectedDate] = useState(new Date('2014-08-18T21:11:54'));
  const [locations, setLocations] = useState();
  const [routes, setRoutes] = useState([]);
  const [from, setFrom] = useState(0);
  const [to, setTo] = useState(1);
  const [weight, setWeight] = useState(0);
  const [height, setHeight] = useState(0);
  const [lenght, setLength] = useState(0);
  const [width, setWidth] = useState(0);
  const [type, setType] = useState(0);

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

  const changeFrom = (event,values) => {
    console.log(event)
    setFrom(values.title);
  };
  const changeTo = (event,values) => {
    console.log(values)
    setTo(values.title);
  };
  const changeWeight = (event) => {
    console.log("Changeweight " +event.target.value)
    setWeight(event.target.value);
  };
  const changeHeight = (event) => {
    setHeight(event.target.value);
  };
  const changeLength = (event) => {
    setLength(event.target.value);
  };
  const changeWidth = (event) => {
    setWidth(event.target.value);
  };
  const changeType = (event,values) => {
    setType(values.title);
  };

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
      from: from,
      to: to,
      weight: weight,
      height: height,
      lenght: lenght,
      width: width,
      type: type,
      date: selectedDate,
    })
    console.log(body)
    fetch('/planroute', {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: body
    }).then(response => response.json())
    .then(data => console.log(data.payload));
  }

  return (
    <Grid container
    spacing={4}
    direction="column"
    alignItems="center"
    justifyContent="center"
    style={{ minHeight: '100vh' }}>
    <Grid item style={{ minWidth: '70vw' }}>
    {typeof selectedRoute !== 'undefined'
    ? <SearchTable routes={routes} selectRoute={selectRoute}/>
    : <SearchBox locations={locations} selectedDate={selectedDate} handleDateChange={handleDateChange} getRoutes={getRoutes} from={from}
    to={to} weight={weight} height={height} lenght={lenght} width={width} type={type} changeFrom={changeFrom} changeTo={changeTo} changeWeight={changeWeight} changeHeight={changeHeight}
    changeLength={changeLength} changeWidth={changeWidth} changeType={changeType}/>
    }
    </Grid>
    <Grid item style={{ minWidth: '90vw' }}>
    {typeof selectedRoute !== 'undefined'
    ? <ConfirmRoute from={from}
    to={to} weight={weight} height={height} lenght={lenght} width={width} type={type}/>
    :<SearchTable routes={routes} selectRoute={selectRoute}/>
    }
    </Grid>
  </Grid>
  );
};