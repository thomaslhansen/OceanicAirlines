import React, { useState } from 'react';
import { withStyles, makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import Button from '@material-ui/core/Button';


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

export default function SearchTable(props) {
  const classes = useStyles();

  return (
    <TableContainer component={Paper}>
      <Table className={classes.table} aria-label="customized table">
        <TableHead>
          <TableRow>
            <StyledTableCell>Route</StyledTableCell>
            <StyledTableCell align="right">Duration</StyledTableCell>
            <StyledTableCell align="right">Cost</StyledTableCell>
            <StyledTableCell align="right"></StyledTableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {props.routes.map((route) => (
            <StyledTableRow key={route.id}>
              <StyledTableCell>{route.id}</StyledTableCell>
              <StyledTableCell align="right">{route.time} h</StyledTableCell>
              <StyledTableCell align="right">{route.cost} $</StyledTableCell>
              <StyledTableCell align="right">                  
                <Button onClick={() => { props.selectRoute(route)}}>
                      Select Route
                </Button>
                </StyledTableCell>
            </StyledTableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}
