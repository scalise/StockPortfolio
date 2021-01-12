<template>
    <v-layout>        
        <v-row>
            <v-col lg="12" md="12">
                <v-data-table :headers="headers"
                              :items="items"
                              :items-per-page="10"
                              class="elevation-1">
                    
                    <template v-slot:item.ticker="{ item }">
                        <a href="#">{{ item.ticker }}</a>
                    </template>

                    <!--  EXAMPLE: customizing grid (color for gain) for single column -->
                    <template v-slot:item.gainValue="{ item }">
                        <v-chip :color="getColor(item.gainValue)" dark>{{ item.gainValue }}</v-chip>
                    </template>

                    <template v-slot:item.actions="{ item }">
                        <v-icon small
                                class="mr-2"
                                @click="editItem(item)">
                            mdi-pencil
                        </v-icon>
                        <v-icon small
                                @click="deleteItem(item)">
                            mdi-delete
                        </v-icon>
                    </template>

                    <template v-slot:top>
                        <!-- Edit Dialog -->
                        <v-dialog v-model="dialog"
                                  max-width="500px">
                            <v-card>
                                <v-card-title>
                                    <span class="headline">Edit Position</span>
                                </v-card-title>
                                <v-card-text>
                                    <v-container>
                                        <v-row>
                                            <v-col cols="12"
                                                   sm="6"
                                                   md="4">
                                                <v-text-field v-model="editedItem.name"
                                                              label="Name"></v-text-field>
                                            </v-col>
                                            <v-col cols="12"
                                                   sm="6"
                                                   md="4">
                                                <v-text-field v-model="editedItem.ticker"
                                                              label="Ticker"></v-text-field>
                                            </v-col>
                                            <v-col cols="12"
                                                   sm="6"
                                                   md="4">
                                                <v-text-field v-model="editedItem.numberOfShares"
                                                              label="# of Shares"></v-text-field>
                                            </v-col>
                                            <v-col cols="12"
                                                   sm="6"
                                                   md="4">
                                                <v-text-field v-model="editedItem.avgPrice"
                                                              label="Avg Purchase Price"></v-text-field>
                                            </v-col>
                                        </v-row>
                                    </v-container>
                                </v-card-text>

                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn color="blue darken-1"
                                           text
                                           @click="close">
                                        Cancel
                                    </v-btn>
                                    <v-btn color="blue darken-1"
                                           text
                                           @click="save">
                                        Save
                                    </v-btn>
                                </v-card-actions>
                            </v-card>
                        </v-dialog>
                        <!-- Delete Dialog -->
                        <v-dialog v-model="dialogDelete" max-width="500px">
                            <v-card>
                                <v-card-title class="headline">Are you sure you want to delete this item?</v-card-title>
                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn color="blue darken-1" text @click="closeDelete">Cancel</v-btn>
                                    <v-btn color="blue darken-1" text @click="deleteItemConfirm">OK</v-btn>
                                    <v-spacer></v-spacer>
                                </v-card-actions>
                            </v-card>
                        </v-dialog>
                    </template>

                </v-data-table>
            </v-col>
        </v-row>
    </v-layout>
</template>
<script>
    import { Position } from '@/store/positions/types';

    export default {
        name: 'StockPositions',
        props: {
            items: {
                type: Array,
            },
        },
        data() {
            return {
                dialog: false,
                dialogDelete: false,
                editedItem: {
                    ticker: '',
                    name: '',
                    numberOfShares: 0,
                    avgPrice: 0.0,
                },
                defaultItem: {
                    ticker: '',
                    name: '',
                    numberOfShares: 0,
                    avgPrice: 0.0,
                },
                editedIndex: -1,
                headers: [
                    { text: 'Name', align: 'start', sortable: false, value: 'name' },
                    { text: 'Symbol', value: 'ticker' },
                    { text: 'Shares', value: 'numberOfShares' },
                    { text: 'Price', value: 'currentPrice' },
                    { text: 'Avg Price', value: 'avgPrice' },
                    { text: 'Market Value', value: 'marketValue' },
                    { text: 'Gain ($)', value: 'gainValue' },
                    { text: 'Gain (%)', value: 'gainPct' },
                    { text: 'Actions', value: 'actions' },
                ],
            };
        },
        methods: {
            getColor(gainValue) {
                if (gainValue < 0) {
                    return 'red';
                } else if (gainValue > 0) {
                    return 'green';
                } else {
                    return 'black';
                }
            },
            editItem(item) {
                this.editedIndex = this.items.indexOf(item);
                this.editedItem = Object.assign({}, item);
                this.dialog = true;
            },
            close() {
                // Use onTick to clear out the edited information being
                // tracked, after the window has closed and the DOM updated.
                this.dialog = false;
                this.$nextTick(() => {
                    this.editedItem = Object.assign({}, this.defaultItem);
                    this.editedIndex = -1;
                });
            },
            save() {
                if (this.editedIndex > -1) {
                    this.$emit('updatedPosition', this.editedItem);
                } else {
                    this.$emit('addedPosition', this.editedItem);
                }
                this.close();
            },
            deleteItem(item) {
                this.editedIndex = this.items.indexOf(item);
                this.editedItem = Object.assign({}, item);
                this.dialogDelete = true;
            },
            deleteItemConfirm() {
                this.$emit('deletedPosition', this.editedItem);
                this.closeDelete();
            },
            closeDelete() {
                this.dialogDelete = false;
                this.$nextTick(() => {
                    this.editedItem = Object.assign({}, this.defaultItem);
                    this.editedIndex = -1;
                });
            },
        },
        watch: {
            dialog(val) {
                val || this.close();
            },
            dialogDelete(val) {
                val || this.closeDelete();
            },
        },
    };
</script>