import React, { useState, useEffect } from 'react';
import Button from "@material-ui/core/Button";
import Card from "@material-ui/core/Card"
import CardContent from "@material-ui/core/CardContent";
import CardActions from "@material-ui/core/CardActions";
import Typography from "@material-ui/core/Typography";
import { withStyles, makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import Autocomplete from '@material-ui/lab/Autocomplete';
import TextField from '@material-ui/core/TextField';
import Select from '@material-ui/core/Select';
import Box from '@material-ui/core/Box';
import MenuItem from '@material-ui/core/MenuItem';

export default function ManageLocation() {

const [rows, setRows] = useState([]);

const updateLocation = async (row) => {
  let status = document.getElementById("locationId" + row.id).textContent
  row.status = status === "Active" ? true : false
  const body = JSON.stringify(row)
  console.log(body)
  const rawResponse = await fetch('/locations', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: body
  });
  console.log(await rawResponse.status)
}

const handleStatusChange = () => {

}
  useEffect(() => {
    fetch('/locations')
  .then(response => response.json())
  .then(data =>setRows(data));
  },[]);


  const StyledTableCell = withStyles((theme) => ({
    head: {
      backgroundColor: '#ffaf00',
      color: '#38383a',
    },
    body: {
      fontSize: 14,
    },
  }))(TableCell);

  const StyledTableRow = withStyles((theme) => ({
    root: {
      '&:nth-of-type(odd)': {
        backgroundColor: theme.palette.action.hover,
      },
    },
  }))(TableRow);

  function createData(route, time, cost) {
    return { route, time, cost};
  }

  const useStyles = makeStyles({
    table: {
      minWidth: 700,
    },
  });
  const classes = useStyles();
  return (
    <TableContainer component={Paper}>
      <Box m={2}>
      <Typography variant="h3">
        Manage Location
      </Typography>
      </Box>
      <Table className={classes.table} aria-label="customized table">
        <TableHead>
          <TableRow>
            <StyledTableCell>Airport</StyledTableCell>
            <StyledTableCell align="right">Status</StyledTableCell>
            <StyledTableCell align="right"></StyledTableCell>

          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map((row) => (
            <StyledTableRow key={row.name}>
              <StyledTableCell>{row.name}</StyledTableCell>
              <StyledTableCell align="right">
                <Select
          labelId="demo-simple-select-label"
          id={"locationId" + row.id}
          defaultValue={row.status}
          onChange={handleStatusChange}
        >
          <MenuItem value={true}>Active</MenuItem>
          <MenuItem value={false}>Inactive</MenuItem>
        </Select>
        </StyledTableCell>
              <StyledTableCell align="right">
                <Button color='primary' variant='contained' onClick={() => { updateLocation(row)}}>
                  Save
                </Button>
                </StyledTableCell>
            </StyledTableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};