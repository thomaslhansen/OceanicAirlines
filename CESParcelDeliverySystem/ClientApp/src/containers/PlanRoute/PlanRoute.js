import React, { useState, useEffect } from 'react';
import SearchBox from '../../components/SearchBox/SearchBox'
import SearchTable from '../../components/SearchTable/SearchTable'
import Grid from '@material-ui/core/Grid';
import ConfirmRoute from '../../components/ConfirmRoute/ConfirmRoute'

export default function PlanRoute() {

  const [selectedDate, setSelectedDate] = useState(new Date());
  const [locations, setLocations] = useState();
  const [routes, setRoutes] = useState([]);
  const [from, setFrom] = useState();
  const [to, setTo] = useState();
  const [weight, setWeight] = useState();
  const [height, setHeight] = useState();
  const [lenght, setLength] = useState();
  const [width, setWidth] = useState();
  const [type, setType] = useState();
  const [selectedRoute, setSelectedRoute] = useState();
  const [email, setEmail] = useState("");
  const [name, setName] = useState("");

  const selectRoute = (route) => {

    setSelectedRoute(route)
    }
  const confirmRoute = () => {
    const body = JSON.stringify({
      fromLocation: from,
      toLocation: to,
      weight: weight,
      height: height,
      lenght: lenght,
      width: width,
      isCancelled: false,
      price: selectedRoute.priceInDollars,
      duration: selectedRoute.durationInHours,
      date: selectedDate,
      customerName: name,
      customerEmail: email
    })
    console.log(body)
    fetch('/orders', {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: body
    }).then(response => response.status)
    .then(data => console.log(data));
    setSelectedRoute()
  }
    const cancel = () => {
    setSelectedRoute()
  }
  const changeFrom = (event,values) => {
    if(values){
      setFrom(values.title);
    }
  };
  const changeTo = (event,values) => {
    if(values){
      setTo(values.title);
    }
  };
  const changeWeight = (event) => {
    console.log("Changeweight " + event.target.value)
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
    if(values){
      setType(values.title);
    }
  };
  const changeEmail = (event) => {
    setEmail(event.target.value);
  };
  const changeName = (event) => {
    setName(event.target.value);
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
    .then(data => setRoutes(data.payload));
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
    ? <SearchTable routes={[selectedRoute]} selectRoute={selectRoute}/>
    : <SearchBox locations={locations} selectedDate={selectedDate} handleDateChange={handleDateChange} getRoutes={getRoutes} from={from}
    to={to} weight={weight} height={height} lenght={lenght} width={width} type={type} changeFrom={changeFrom} changeTo={changeTo} changeWeight={changeWeight} changeHeight={changeHeight}
    changeLength={changeLength} changeWidth={changeWidth} changeType={changeType}/>
    }
    </Grid>
    <Grid item style={{ minWidth: '90vw' }}>
    {typeof selectedRoute !== 'undefined'
    ? <ConfirmRoute from={from}
    to={to} weight={weight} height={height} lenght={lenght} width={width} type={type} name={name} email={email} date={selectedDate}
     changeEmail={changeEmail} changeName={changeName} confirmRoute={confirmRoute} cancel={cancel}/>
    :<SearchTable routes={routes} selectRoute={selectRoute} />
    }
    </Grid>
  </Grid>
  );
};