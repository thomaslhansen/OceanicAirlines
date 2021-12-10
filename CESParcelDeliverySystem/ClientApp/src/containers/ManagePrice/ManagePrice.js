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
import TextField from '@material-ui/core/TextField';


export default function ManageLocation() {

const [rows, setRows] = useState([]);

const updatePrice = async (row) => {

  row.price1.currentPrice = document.getElementById("priceId"+row.price1.id).value
  row.price2.currentPrice = document.getElementById("priceId"+row.price2.id).value
  row.price3.currentPrice = document.getElementById("priceId"+row.price3.id).value
  
  console.log("priceId"+row.price1.id)
  console.log("priceId"+row.price2.id)
  console.log("priceId"+row.price3.id)

  const body1 = JSON.stringify(row.price1)
  console.log(body1)
  const body2 = JSON.stringify(row.price2)
  console.log(body2)
  const body3 = JSON.stringify(row.price3)
  console.log(body3)


  const rawResponse1 = await fetch('/prices', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: body1
  });
  console.log(await rawResponse1.status)

  const rawResponse2 = await fetch('/prices', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: body2
  });
  console.log(await rawResponse2.status)

  const rawResponse3 = await fetch('/prices', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: body3
  });
  console.log(await rawResponse3.status)
}


  useEffect(() => {
    fetch('/prices')
  .then(response => response.json())
  .then(data =>
  setRows([
    createData('<1 kg',data.find(element => element.id === 1), data.find(element => element.id === 2),data.find(element => element.id === 3)),
    createData('1-5 kg', data.find(element => element.id === 4), data.find(element => element.id === 5),data.find(element => element.id === 6)),
    createData('>5 kg', data.find(element => element.id === 7), data.find(element => element.id === 8),data.find(element => element.id === 9)),
  ]))
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

  function createData(weightRange, price1, price2, price3) {
    return { weightRange, price1, price2, price3};
  }
  
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
            <StyledTableCell>Weight</StyledTableCell>
            <StyledTableCell align="right">A</StyledTableCell>
            <StyledTableCell align="right">B</StyledTableCell>
            <StyledTableCell align="right">C</StyledTableCell>
            <StyledTableCell align="right"></StyledTableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map((row) => (
            <StyledTableRow key={row.name}>
              <StyledTableCell>{row.weightRange}</StyledTableCell>
              <StyledTableCell align="right"><TextField id={"priceId"+row.price1.id} type="number" defaultValue={row.price1.currentPrice}/> $</StyledTableCell>
              <StyledTableCell align="right"><TextField id={"priceId"+row.price2.id} type="number" defaultValue={row.price2.currentPrice}/> $</StyledTableCell>
              <StyledTableCell align="right"><TextField id={"priceId"+row.price3.id} type="number" defaultValue={row.price3.currentPrice}/> $</StyledTableCell>
              <StyledTableCell align="right">
                <Button color='primary' variant='contained' onClick={() => { updatePrice(row)}}>
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