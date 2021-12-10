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

export default function SearchBox(props) {

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
                <TextField id="weight" label="Weight" type="number" onChange={props.changeWeight} value={props.weight}/>
              </ListItem>
              <ListItem>
                <TextField id="height" label="Height" type="number" onChange={props.changeHeight} value={props.height}/>
              </ListItem>
              <ListItem>
                <TextField id="length" label="Length" type="number" onChange={props.changeLength} value={props.length}/>
              </ListItem>
              <ListItem>
                <TextField id="width" label="Width" type="number" onChange={props.changeWidth} value={props.width}/>
              </ListItem>
              <ListItem>
              <Autocomplete
                id="type"
                options={[{title: 'Recorded Delivery'},{title: 'Weapons'},{title: 'Cautios parcel'},{title: 'Refigerated goods'}]}
                getOptionLabel={(option) => option.title}
                style={{ width: 300 }}
                onChange={props.changeType}
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
                  options={props.locations}
                  getOptionLabel={(option) => option.title}
                  style={{ width: 300 }}
                  onChange={props.changeFrom}
                  renderInput={(params) => <TextField {...params} label="From" variant="outlined" />}
                />
              </Grid>
                <Grid item xs={1}>
                <Autocomplete
                  id="to"
                  options={props.locations}
                  getOptionLabel={(option) => option.title}
                  style={{ width: 300 }}
                  onChange={props.changeTo}
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
                  value={props.selectedDate}
                  onChange={props.handleDateChange}
                  KeyboardButtonProps={{
                      'aria-label': 'change date',
                  }}
                  />
              </MuiPickersUtilsProvider>
              </Grid>
              <Box mt={20} mr={2}>
                <ButtonGroup variant='contained' color="primary" aria-label="contained primary button group">
                  <Button onClick={() => { props.getRoutes("fastest")}}>
                    Search fastest route
                  </Button>
                  <Button onClick={() => { props.getRoutes("cheapest")}}>
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