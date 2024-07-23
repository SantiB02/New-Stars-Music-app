import {
  Typography,
  Button,
  Tabs,
  TabsHeader,
  Tab,
  TabsBody,
  TabPanel,
} from "@material-tailwind/react";
import React, { useState, useEffect } from "react";
import api from "../../api/api";
import { useTheme } from "../../services/contexts/ThemeProvider";
import UsersReport from "./UsersReport";
import ProductsReport from "./ProductsReport";
import SaleOrdersReport from "./SaleOrdersReport";
import LoadingMessage from "../common/LoadingMessage";

const Dashboard = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [users, setUsers] = useState(null);
  const [products, setProducts] = useState(null);
  const [saleOrders, setSaleOrders] = useState(null);
  const [error, setError] = useState(null);

  const { theme } = useTheme();

  useEffect(() => {
    const fetchData = async () => {
      setIsLoading(true);
      try {
        const [productListResponse, usersResponse, saleOrdersResponse] =
          await Promise.all([
            api.get("/products"),
            api.get("/users"),
            api.get("/sale-orders"),
          ]);

        setUsers(usersResponse.data);
        setProducts(productListResponse.data);
        setSaleOrders(saleOrdersResponse.data);
        setError(null);
      } catch (error) {
        console.log("Error", error);
        setError(error.message || "Error fetching data");
      } finally {
        setIsLoading(false);
      }
    };
    fetchData();

    return () => {
      setUsers(null);
      setProducts(null);
      setSaleOrders(null);
    };
  }, []);

  if (isLoading) return <LoadingMessage message="Loading reports..." />;

  return (
    <div className="max-w-7xl mx-8 py-6">
      <Typography variant="h2" className="font-light">
        Dashboard
      </Typography>
      {error ? (
        <div>Error: {error}</div>
      ) : (
        <Tabs value="users">
          <TabsHeader className="bg-transparent">
            <Tab
              value="users"
              className="mx-2 md:mx-10 rounded-full bg-orange-500"
            >
              Users
            </Tab>
            <Tab
              value="products"
              className="mx-2 md:mx-10 rounded-full bg-orange-500"
            >
              Products
            </Tab>
            <Tab
              value="sale orders"
              className="mx-2 md:mx-10 rounded-full bg-orange-500"
            >
              Sale Orders
            </Tab>
          </TabsHeader>
          <TabsBody>
            <TabPanel value="users">
              <UsersReport users={users} theme={theme} />
            </TabPanel>
            <TabPanel value="products">
              <ProductsReport products={products} theme={theme} />
            </TabPanel>
            <TabPanel value="sale orders">
              <SaleOrdersReport
                saleOrders={saleOrders}
                setSaleOrders={setSaleOrders}
                theme={theme}
              />
            </TabPanel>
          </TabsBody>
        </Tabs>
      )}
    </div>
  );
};

export default Dashboard;
