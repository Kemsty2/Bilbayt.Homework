import { Link } from "react-router-dom";
import { useFormik } from "formik";
import * as Yup from "yup";

import { FormContainer } from "../../Container/AuthContainer.styles";
import FormInput from "../../UIs/FormInput/FormInput.ui";
import ButtonOrange from "../../UIs/ButtonOrange/ButtonOrange.ui";

import routes from "../../../configs/routes";

const RegisterForm = ({ isLoading = false, onSubmit }) => {
  const validationSchema = Yup.object().shape({
    userName: Yup.string()
      .required("UserName is required")
      .email("Please enter a valid email"),
    password: Yup.string()
      .required("Password is required")
      .matches(
        "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
        "Minimum eight characters, at least one uppercase letter, one lowercase letter and one number"
      ),
    confirmPassword: Yup.string()
      .required("ConfirmPassword is required")
      .matches(
        "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
        "Minimum eight characters, at least one uppercase letter, one lowercase letter and one number"
      )
      .oneOf([Yup.ref("password"), null], "Passwords must match"),
    fullName: Yup.string().required("FullName is required"),
  });
  const formik = useFormik({
    initialValues: {
      userName: "",
      password: "",
      fullName: "",
      confirmPassword: "",
    },
    validationSchema,
    onSubmit,
  });

  return (
    <FormContainer onSubmit={formik.handleSubmit}>
      <div className="form-group">
        <FormInput
          className="form-control"
          placeholder="UserName"
          onChange={formik.handleChange}
          name="userName"
          onBlur={formik.handleBlur}
          invalid={formik.touched.userName && formik.errors.userName}
        />
        {formik.touched.userName && formik.errors.userName && (
          <small className="form-text text-danger">
            {formik.errors.userName}
          </small>
        )}
      </div>
      <div className="form-group">
        <FormInput
          className="form-control"
          placeholder="FullName"
          onChange={formik.handleChange}
          name="fullName"
          onBlur={formik.handleBlur}
          invalid={formik.touched.fullName && formik.errors.fullName}
        />
        {formik.touched.fullName && formik.errors.fullName && (
          <small className="form-text text-danger">
            {formik.errors.fullName}
          </small>
        )}
      </div>
      <div className="form-group d-inline">
        <FormInput
          className="form-control"
          placeholder="Password"
          type="password"
          showable={true}
          onChange={formik.handleChange}
          name="password"
          onBlur={formik.handleBlur}
          invalid={formik.touched.password && formik.errors.password}
        />
        {formik.touched.password && formik.errors.password && (
          <small className="form-text text-danger">
            {formik.errors.password}
          </small>
        )}
      </div>

      <div className="form-group d-inline">
        <FormInput
          className="form-control"
          placeholder="Confirm Password"
          type="password"
          showable={true}
          onChange={formik.handleChange}
          name="confirmPassword"
          onBlur={formik.handleBlur}
          invalid={
            formik.touched.confirmPassword && formik.errors.confirmPassword
          }
        />
        {formik.touched.confirmPassword && formik.errors.confirmPassword && (
          <small className="form-text text-danger mt-1 mb-2">
            {formik.errors.confirmPassword}
          </small>
        )}
      </div>

      <div className="d-flex justify-content-between align-items-center">
        <ButtonOrange isLoading={isLoading} type="submit">
          SignUp
        </ButtonOrange>
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
