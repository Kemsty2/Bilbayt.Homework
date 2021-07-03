import { useEffect } from "react";
import { ToastContainer } from "react-toastify";
import { createStructuredSelector } from "reselect";
import { connect } from "react-redux";
import Routes from "./routes/MainRoutes";

import { selectUserToken } from "./store/reducers/users/users.selectors";
import { setAuthToken } from "./utils";

const App = ({ token }) => {
  useEffect(() => {
    setAuthToken(token);
  }, [token]);

  return (
    <>
      <Routes />
      <ToastContainer
        position="top-right"
        autoClose={5000}
        hideProgressBar={true}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
      />
    </>
  );
};

const mapStateToProps = createStructuredSelector({
  token: selectUserToken,
});

export default connect(mapStateToProps, {})(App);
