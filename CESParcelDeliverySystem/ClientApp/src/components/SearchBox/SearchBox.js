import React, { useState, useEffect  } from 'react';
import Button from "@material-ui/core/Button";
import Card from "@material-ui/core/Card"
import CardContent from "@material-ui/core/CardContent";
import CardActions from "@material-ui/core/CardActions";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import Typography from "@material-ui/core/Typography";
import Autocomplete from '@material-ui/lab/Autocomplete';
import { KeyboardDatePicker, MuiPickersUtilsProvider } from '@material-ui/pickers';
import DateFnsUtils from '@date-io/date-fns';
import Box from '@material-ui/core/Box';
import ButtonGroup from "@material-ui/core/ButtonGroup";


export default function SearchBox() {

  const [selectedDate, setSelectedDate] = useState(new Date('2014-08-18T21:11:54'));
  const [locations, setLocations] = useState();


  const handleDateChange = (date) => {
    setSelectedDate(date);
  };

  const setLocationData = (data) =>{
    setLocations(data.map(location => ({title: location.locationName, id: location.locationId})))
  }

  useEffect(() => {
    fetch('/getlocations')
  .then(response => response.json())
  .then(data => setLocationData(data));
  },[]);

  const getCheapestRoute = () => {
  }
  const getFastestRoute = () => {

  }


  return (
      <Card>
        <CardContent>
        <Grid container spacing={5}>
          <Grid item xs={4}>
          <Typography variant="h6">
              Parcel
          </Typography>
            <List>
              <ListItem>
                <TextField id="weigth" label="Weight" />
              </ListItem>
              <ListItem>
                <TextField id="height" label="Height" />
              </ListItem>
              <ListItem>
                <TextField id="Length" label="Length" />
              </ListItem>
              <ListItem>
                <TextField id="width" label="Width" />
              </ListItem>
              <ListItem>
              <Autocomplete
                id="type"
                options={[{title: 'test'}]}
                getOptionLabel={(option) => option.title}
                style={{ width: 300 }}
                renderInput={(params) => <TextField {...params} label="Type" variant="outlined" />}
              />
              </ListItem>
            </List>
          </Grid>
          <Grid item xs={4}>
            <Grid container spacing={3} direction="column">
              <Grid item xs={1}>
              <Typography variant="h6">
                  Location
              </Typography>
              </Grid>
              <Grid item xs={1}>
                <Autocomplete
                  id="from"
                  options={locations}
                  getOptionLabel={(option) => option.title}
                  style={{ width: 300 }}
                  renderInput={(params) => <TextField {...params} label="From" variant="outlined" />}
                />
              </Grid>
                <Grid item xs={1}>
                <Autocomplete
                  id="to"
                  options={locations}
                  getOptionLabel={(option) => option.title}
                  style={{ width: 300 }}
                  renderInput={(params) => <TextField {...params} label="To" variant="outlined" />}
                />
              </Grid>
            </Grid>
          </Grid>
          <Grid item xs={4}>
          <Typography variant="h6">
            Date
          </Typography>
            <Grid container direction='column' spacing={6}>
              <Grid item xs={12}>
              <MuiPickersUtilsProvider utils={DateFnsUtils}>
                <KeyboardDatePicker
                  disableToolbar
                  variant="inline"
                  format="MM/dd/yyyy"
                  margin="normal"
                  id="date-picker-inline"
                  label="Date picker inline"
                  value={selectedDate}
                  onChange={handleDateChange}
                  KeyboardButtonProps={{
                      'aria-label': 'change date',
                  }}
                  />
              </MuiPickersUtilsProvider>
              </Grid>
              <Box mt={20} mr={2}>
                <ButtonGroup variant='contained' color="primary" aria-label="contained primary button group">
                  <Button onClick={getFastestRoute}>
                    Search fastest route
                  </Button>
                  <Button onClick={getCheapestRoute}>
                    Search cheapest route
                  </Button>
                </ButtonGroup>
                </Box>  
              </Grid>
          </Grid>
        </Grid>
        </CardContent>
        <CardActions>
        </CardActions>
      </Card>
  );
};