import styled, { css } from "styled-components";
import { Link } from "react-router-dom";

export const HeaderContainer = styled.header`
  box-shadow: 0 0.125rem 0.25rem rgba(0, 0, 0, 0.075) !important;

  @media screen and (max-width: 702px) {
    position: relative !important;
    background-color: #000;
  }
`;

export const NavBarContainer = styled.nav`
  padding-top: 15px !important;
  background-color: #fff;
  transition: background-color 0.3s ease-in-out !important;
`;

export const NavBarContent = styled.div`
  padding-right: 25px !important;
  padding-left: 25px !important;
  max-width: 100% !important;
`;

export const AvatarIcon = styled.div`
  height: 36px;
  width: 36px;
  border-radius: 50%;
  background-color: #f16e00;
  color: #fff;
  display: flex;
  justify-content: center;
  align-items: center;
  text-transform: capitalize;
`;

export const AvatarName = styled.span`
  color: #000;
  font-weight: normal;
  font-size: 14px;
  margin: 0 10px;
  display: block;
  max-width: 88px;
  text-overflow: ellipsis;
  white-space: nowrap;
  overflow: hidden;
`;
const DropMenuInfoCss = css`
  font-weight: bold;
  font-size: 14px;
  color: rgba(0, 0, 0, 0.67);
  display: block;
  line-height: 140.62%;
`;
export const DropDownMenu = styled.div`
  position: absolute;
  top: 50px;
  left: unset !important;
  right: 20px;
  width: 240px;
  z-index: 2;
  background: #ffffff;
  -webkit-box-shadow: 0px 4px 4px rgb(0 0 0 / 8%);
  box-shadow: 0px 4px 4px rgb(0 0 0 / 8%);
  border-radius: 7px;
  border: none;
  overflow: hidden;
`;
export const DropDownMenuInfo = styled.div`
  background: rgba(0, 0, 0, 0.08);
  padding: 12px;
`;
export const DropDownMenuInfoName = styled.span`
  ${DropMenuInfoCss}
`;
export const DropDownMenuInfoEmail = styled.span`
  ${DropMenuInfoCss}
  font-size: 11px;
  color: $orange;
  text-decoration: none;
`;

const DropDownItem = css`
  font-weight: bold;
  font-size: 11px;
  color: rgba(0, 0, 0, 0.67) !important;
  display: block;
  padding: 15px 10px;
  background-color: #fff;

  &.no-underline:hover {
    text-decoration: none !important;
  }

  @media screen and (max-width: 768px) {
    background-color: #fff;
    border: none;
  }

  &:hover {
    background-color: #f5f5f5 !important;
    color: rgba(0, 0, 0, 0.67) !important;
    text-decoration: none;
  }
  &:focus {
    background-color: #f5f5f5 !important;
    color: rgba(0, 0, 0, 0.67) !important;
    text-decoration: none;
  }
`;
export const DropDownItemLink = styled(Link)`
  ${DropDownItem}
`;

export const DropDownItemButton = styled.button`
  ${DropDownItem}
`;
