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

export default function ConfirmRoute(props) {

  const confirmRoute = () => {
    
  }
  const cancel = () => {
    
  }
  return (
      <Card>
        <CardContent>
        <Grid container spacing={0}>
          <Grid item xs={4}>
          <Typography variant="h5">
              Parcel
          </Typography>
            <List>
              <ListItem>
              <Typography variant="h6">
                  Weight:
              </Typography>
              </ListItem>
              <ListItem>
              <Typography variant="h6">
                  Length:
              </Typography>
              </ListItem>
              <ListItem>
              <Typography variant="h6">
                  Width:
              </Typography>
              </ListItem>
              <ListItem>
              <Typography variant="h6">
                  Height:
              </Typography>
              </ListItem>
              <ListItem>
              <Typography variant="h6">
                  Type:
              </Typography>
              </ListItem>
            </List>
          </Grid>
          <Grid item xs={4}>
            <Grid container spacing={3} direction="column">
              <Grid item xs={5}>
              <Typography variant="h6">
                  Customer
              </Typography>
              </Grid>
              <Grid item xs={5}>
              <TextField id="email" label="Email" type="mail"/>
              </Grid>
                <Grid item xs={5}>
                <TextField id="weight" label="Name" type="name"/>
              </Grid>
            </Grid>
          </Grid>
          <Grid item xs={4}>
            <Typography variant="h6">
                Date:
            </Typography>
            <Box mt={20} mr={2} spacing={1}>
            <ButtonGroup variant='contained' aria-label="contained primary button group">
                <Button color="warning" onClick={ cancel }>
                  Cancel
                </Button>
                <Button color="primary" onClick={ confirmRoute }>
                  Confirm Route
                </Button>
              </ButtonGroup>
              </Box>  
          </Grid>
        </Grid>
        </CardContent>
        <CardActions>
        </CardActions>
      </Card>
  );
};