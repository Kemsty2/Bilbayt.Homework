import React from "react";
import { Route, Redirect } from "react-router-dom";
import { connect } from "react-redux";
import { createStructuredSelector } from "reselect";

import { selectUserIsAuthenticated } from "../../../store/reducers/users/users.selectors";

const PrivateRoute = ({ component: Component, isAuthenticated, ...rest }) => {
  return (
    <Route
      {...rest}
      render={(props) =>
        isAuthenticated ? <Component {...props} /> : <Redirect to="/login" />
      }
    />
  );
};

const mapStateToProps = createStructuredSelector({
  isAuthenticated: selectUserIsAuthenticated,
});

export default connect(mapStateToProps)(PrivateRoute);
