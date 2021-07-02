import loadable from "@react-loadable/revised";
import { Switch, Route, Redirect } from "react-router-dom";

import SpinLoader from "../components/Loaders/spinner/spinner.component";
import routes from "../configs/routes";
import WithAuthContainer from "../components/HOCs/WithAuthContainer/WithAuthContainer.hoc";
import WithPageContainer from "../components/HOCs/WithPageContainer/WithPageContainer.hoc";

const Home = loadable({
  loader: () => import("../containers/Home/home.container"),
  loading: SpinLoader,
});

const Login = loadable({
  loader: () => import("../containers/Login/login.container"),
  loading: SpinLoader,
});

const Register = loadable({
  loader: () => import("../containers/Register/register.container"),
  loading: SpinLoader,
});

const NotFound = loadable({
  loader: () => import("../pages/Home/home.page"),
  loading: SpinLoader,
});

const Routes = () => {
  return (
    <Switch>
      <Route path={routes.home} component={WithPageContainer(Home)} exact />
      <Route path={routes.login} component={WithAuthContainer(Login)} exact />
      <Route
        path={routes.signup}
        component={WithAuthContainer(Register)}
        exact
      />
      <Route path={routes.notfound} component={NotFound} />
      <Redirect to={routes.notfound} />
    </Switch>
  );
};

export default Routes;
