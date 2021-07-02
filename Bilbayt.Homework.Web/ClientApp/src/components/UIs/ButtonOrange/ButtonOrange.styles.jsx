import styled, { css } from "styled-components";
import { Link } from "react-router-dom";

const Styles = css`
  display: inline-flex;
  align-items: center;
  justify-content: center;
  text-decoration: none !important;
  border-radius: 3px;
  height: 40px;
  border: none;
  color: #fff;
  font-weight: bold;
  font-size: 14px;
  line-height: 17px;
  padding: 7px 14px;
  white-space: nowrap;
  min-width: 100px;
  ${(props) => {
    if (props.disabled) {
      return "background: #ccc; color: #fff;";
    }
    if (props.classbutton === "primary") {
      return "background: #f16e00; color: #fff;";
    }

    if (props.classbutton === "default") {
      return "background: #F3F3F4; color: #000000;";
    }

    if (props.classbutton === "secondary") {
      return "background: #000; color: #fff;";
    }

    if (props.classbutton === "danger") {
      return "background: #cd3c14; color: #fff;";
    }
  }};
`;

const StylesWithIcon = css`
  justify-content: space-between;
  height: 44px;
  padding: 7px 8px 7px 14px;
`;

export const Button = styled.button`
  ${Styles}
  display: flex;

  ${(props) => props.icon && StylesWithIcon}
`;

export const LinkButton = styled(Link)`
  ${Styles}

  ${(props) => props.icon && StylesWithIcon}

  &:hover,
  &:focus {
    color: #fff;
  }
`;

export const ClassicLinkButton = styled.a`
  ${Styles}

  ${(props) => props.icon && StylesWithIcon}

  &:hover,
  &:focus {
    color: #fff;
  }
`;

export const ClassicLink = styled.a``;

export const Span = styled.span`
  display: flex;
  justify-content: center;
  align-items: center;
  background: #ffffff;
  border-radius: 4px;
  width: 33px;
  height: 33px;
  margin-left: 6px;
`;
