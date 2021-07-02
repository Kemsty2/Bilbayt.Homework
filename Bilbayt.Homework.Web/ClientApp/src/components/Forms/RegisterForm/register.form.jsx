import { Link } from "react-router-dom";

import { FormContainer } from "../../Container/AuthContainer.styles";
import FormInput from "../../UIs/FormInput/FormInput.ui";
import ButtonOrange from "../../UIs/ButtonOrange/ButtonOrange.ui";

import routes from "../../../configs/routes";

const RegisterForm = () => {
  return (
    <FormContainer>
      <div className="form-group">
        <FormInput className="form-control" placeholder="UserName" />
      </div>
      <div className="form-group">
        <FormInput className="form-control" placeholder="FullName" />
      </div>
      <div className="form-group d-inline">
        <FormInput
          className="form-control"
          placeholder="Password"
          type="password"
          showable={true}
        />
      </div>

      <div className="form-group d-inline">
        <FormInput
          className="form-control"
          placeholder="Confirm Password"
          type="password"
          showable={true}
        />
      </div>

      <div className="d-flex justify-content-between align-items-center">
        <ButtonOrange>SignUp</ButtonOrange>
        <span className="special-text">
          Alrealy Have an Account,{" "}
          <Link className="text-orange" to={routes.login}>
            {" "}
            Sign In
          </Link>
        </span>
      </div>
    </FormContainer>
  );
};

export default RegisterForm;
