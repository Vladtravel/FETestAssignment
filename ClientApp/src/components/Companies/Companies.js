import React from "react";
import { useState, useEffect } from "react";
import API from "../../serviceApi/serviceApi";

import s from "./Companies.module.css";

const Companies = () => {
  const [company, setCompany] = useState(null);
  useEffect(() => {
    API.GetAllCompanies()
      .then((data) => {
        setCompany(data);
      })
      .catch((error) => console.warn(error));
  }, []);

  function handelAdd(registryCode) {
    API.GetRequestedCompany(registryCode).then((data) => {
      API.GetAllCompanies();
    });
  }

  return (
    <>
      {company && (
        <ul className={s.companyList}>
          {company.map((el) => (
            <li className={el.id === null ? s.companyItem : s.companyItemMy} key={el.name}>
              <h2 className={s.companyItemTitle}>{el.name}</h2>
              <p className={s.companyItemReg}>Reg.nr: {el.registryCode}</p>
              {el.id === null && (
                <button
                  className={s.companyItemButton}
                  onClick={() => handelAdd(el.registryCode)}
                  type="button"
                >
                  ADD TO SYSTEM
                </button>
              )}
            </li>
          ))}
        </ul>
      )}
    </>
  );
};

export default Companies;
