import React, { useState } from 'react';
import SearchBox from '../../components/SearchBox/SearchBox'
import SearchTable from '../../components/SearchTable/SearchTable'
import Grid from '@material-ui/core/Grid';

export default function PlanRoute() {

  return (

      <Grid container
        spacing={4}
        direction="column"
        alignItems="center"
        justifyContent="center"
        style={{ minHeight: '100vh' }}>
          <Grid item style={{ minWidth: '70vw' }}>
          <SearchBox/>
          </Grid>
          <Grid item style={{ minWidth: '90vw' }}>
          <SearchTable/>
          </Grid>
        </Grid>
  );
};