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

  const [selectedFromDate, setSelectedFromDate] = useState(new Date('2014-08-18T21:11:54'));
  const [selectedToDate, setSelectedToDate] = useState(new Date('2014-08-18T21:11:54'));

  const getData = async () => {
    const body = JSON.stringify({
      from: selectedFromDate,
      to: selectedToDate,
    })
    console.log(body)
    const rawResponse = await fetch('/ExportData', {
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
      <Card>
        <CardContent>
        <Grid container
          spacing={0}
          direction="column"
          alignItems="center"
          justifyContent="center"
          style={{ minHeight: '50vh' }}>
            <Grid container direction='column' spacing={6}           
              direction="column"
              alignItems="center"
              justifyContent="center">
              <Box mt={4}>
                <Typography variant="h3">
                  Export Data
                </Typography>
              </Box>
              <MuiPickersUtilsProvider utils={DateFnsUtils}>
                <KeyboardDatePicker
                  disableToolbar
                  variant="inline"
                  format="MM/dd/yyyy"
                  margin="normal"
                  id="date-picker-inline"
                  label="From"
                  value={selectedFromDate}
                  onChange={setSelectedFromDate}
                  KeyboardButtonProps={{
                      'aria-label': 'change date',
                  }}
                  />
              </MuiPickersUtilsProvider>
              <MuiPickersUtilsProvider utils={DateFnsUtils}>
                <KeyboardDatePicker
                  disableToolbar
                  variant="inline"
                  format="MM/dd/yyyy"
                  margin="normal"
                  id="date-picker-inline"
                  label="To"
                  value={selectedToDate}
                  onChange={setSelectedToDate}
                  KeyboardButtonProps={{
                      'aria-label': 'change date',
                  }}
                  />
              </MuiPickersUtilsProvider>
              <Box mt={20} mr={2}>
                <Button color='primary' variant='contained'onClick={getData}>
                  Export Data
                </Button>
                </Box>  
              </Grid>
        </Grid>
        </CardContent>
        <CardActions>
        </CardActions>
      </Card>
  );
};