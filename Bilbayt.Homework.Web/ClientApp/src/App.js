import { Provider } from "react-redux";
import { PersistGate } from "redux-persist/integration/react";
import { ConnectedRouter } from "connected-react-router";
import { history } from "./store/reducers/rootReducer";

import { store, persistor } from "./store";
import Routes from "./routes/MainRoutes";

const App = () => {
  return (
    <Provider store={store}>
      <ConnectedRouter history={history}>
        <PersistGate persistor={persistor}>
          <Routes />
        </PersistGate>
      </ConnectedRouter>
    </Provider>
  );
};

export default App;
