import { Provider } from "react-redux";
import { PersistGate } from "redux-persist/integration/react";
import { ConnectedRouter } from "connected-react-router";
import { ToastContainer } from "react-toastify";

import { history } from "./store/reducers/rootReducer";
import { store, persistor } from "./store";
import Routes from "./routes/MainRoutes";

const App = () => {
  return (
    <Provider store={store}>
      <ConnectedRouter history={history}>
        <PersistGate persistor={persistor}>
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
        </PersistGate>
      </ConnectedRouter>
    </Provider>
  );
};

export default App;
