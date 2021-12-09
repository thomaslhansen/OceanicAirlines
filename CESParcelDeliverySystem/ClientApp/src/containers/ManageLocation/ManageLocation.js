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


export default function ManageLocation() {

var prices

const updatePrice = async () => {
  console.log(prices)
  const body = JSON.stringify({ id: 1, sizeCategory: "A", weightCategory: 'Light', currentPrice: 40, latestShippingPrice: 0, latestTruckingPrice: 0 })
  console.log(body)
  const rawResponse = await fetch('/prices', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: body
  });
  const content = await rawResponse.json();
  fetch('/price')
.then(response => response.status)
.then(status => console.log(status));
}


  useEffect(() => {
    fetch('/prices')
  .then(response => response.json())
  .then(data => prices = {


  });
  },[]);


  const StyledTableCell = withStyles((theme) => ({
    head: {
      backgroundColor: theme.palette.common.black,
      color: theme.palette.common.white,
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
  const rows = [
    createData('Frozen yoghurt', 72,340),
    createData('Ice cream sandwich', 86, 888),
    createData('Eclair', 262, 999),
    createData('Cupcake', 305, 1050),
    createData('Gingerbread', 356, 1500)
  ];
  const useStyles = makeStyles({
    table: {
      minWidth: 700,
    },
  });
  const classes = useStyles();
  return (
    <TableContainer component={Paper}>
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
              <StyledTableCell>{row.route}</StyledTableCell>
              <StyledTableCell align="right">{row.time} h</StyledTableCell>
              <StyledTableCell align="right">
                <Button color='primary' variant='contained'>
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