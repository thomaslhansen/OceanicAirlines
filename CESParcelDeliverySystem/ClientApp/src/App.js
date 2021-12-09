import React from "react";
import {
  BrowserRouter as Router,
  Route,
  Switch
} from "react-router-dom";
import CssBaseline from "@material-ui/core/CssBaseline";
import { MuiThemeProvider } from "@material-ui/core/styles";
import { createMuiTheme } from "@material-ui/core/styles";
import { useSelector } from 'react-redux';

import Home from "./containers/Home/Home";
import Setting from "./containers/Setting/Setting";
import PlanRoute from "./containers/PlanRoute/PlanRoute";
import ManageLocation from "./containers/ManageLocation/ManageLocation";
import ManagePrice from "./containers/ManagePrice/ManagePrice";
import ExportData from "./containers/ExportData/ExportData";


import MainLayout from "./layouts/MainLayout";
import EmptyLayout from "./layouts/EmptyLayout";

import { getTheme } from "./containers/Setting/settingsReducer";

const NotFound = () => {
  return <div>NotFound</div>;
};

const DashboardRoute = ({ component: Component, ...rest }) => {
  return (
    <Route
      {...rest}
      render={matchProps => (
        <MainLayout>
          <Component {...matchProps} />
        </MainLayout>
      )}
    />
  );
};

const EmptyRoute = ({ component: Component, ...rest }) => {
  return (
    <Route
      {...rest}
      render={matchProps => (
        <EmptyLayout>
          <Component {...matchProps} />
        </EmptyLayout>
      )}
    />
  );
};

export default function App() {

  const theTheme = useSelector(getTheme);

     return (
      <MuiThemeProvider theme={createMuiTheme(theTheme)}>
        <CssBaseline />
        <div style={{ height: "100vh" }}>
          <Router>
            <Switch>
              <DashboardRoute path="/dashboard" component={Home} />
              <DashboardRoute path="/plan-route" component={PlanRoute} />
              <DashboardRoute path="/manage-location" component={ManageLocation} />
              <DashboardRoute path="/manage-price" component={ManagePrice} />
              <DashboardRoute path="/export-data" component={ExportData} />
              <DashboardRoute path="/setting" component={Setting} />
              <DashboardRoute exact path="/" component={PlanRoute} />
              <EmptyRoute component={NotFound} />
            </Switch>
          </Router>
        </div>
      </MuiThemeProvider>
    );
};