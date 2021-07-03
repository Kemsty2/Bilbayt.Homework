import React from "react";
import { Route, Redirect } from "react-router-dom";
import { connect } from "react-redux";
import { createStructuredSelector } from "reselect";

import { selectUserIsAuthenticated } from "../../../store/reducers/users/users.selectors";

const PublicRoute = ({ component: Component, isAuthenticated, ...rest }) => {
  return (
    <Route
      {...rest}
      render={(props) =>
        isAuthenticated ? <Redirect to="/" /> : <Component {...props} />
      }
    />
  );
};

const mapStateToProps = createStructuredSelector({
  isAuthenticated: selectUserIsAuthenticated,
});

export default connect(mapStateToProps)(PublicRoute);
