<template>
    <v-row justify="center">
        <v-dialog v-model="dialog"
                  persistent
                  max-width="600px">
            <template v-slot:activator="{ on, attrs }">
                <v-btn color="primary"
                       dark
                       v-bind="attrs"
                       v-on="on">
                    New Position
                </v-btn>
            </template>
            <v-card>
                <v-card-title>
                    <span class="headline">New Position</span>
                </v-card-title>
                <v-card-text>
                    <v-container>
                        <v-row>
                            <v-col cols="12"
                                   sm="6"
                                   md="4">
                                <v-text-field label="Stock Name"
                                              v-model="model.name"
                                              required></v-text-field>
                            </v-col>
                            <v-col cols="12"
                                   sm="6"
                                   md="4">
                                <v-text-field label="Ticker Symbol"
                                              v-model="model.ticker"></v-text-field>
                            </v-col>
                            <v-col cols="12"
                                   sm="6"
                                   md="4">
                                <v-text-field label="# of Shares"
                                              v-model="model.numberOfShares"
                                              hint="Number of shares purchased"
                                              persistent-hint
                                              required></v-text-field>
                            </v-col>
                            <v-col cols="12">
                                <v-text-field label="Share Price"
                                              v-model="model.avgPrice"
                                              required></v-text-field>
                            </v-col>                            
                        </v-row>
                    </v-container>                    
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="blue darken-1"
                           text
                           @click="close">
                        Close
                    </v-btn>
                    <v-btn color="blue darken-1"
                           text
                           @click="submit">
                        Save
                    </v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </v-row>
</template>
<script>
    export default {
        name: 'AddPosition',        
        data() {
            return {
                dialog: false,
                model: {},
            }
        },
        methods: {
            close() {
                this.dialog = false;
                this.model = {}
            },
            submit() {
                this.dialog = false;
                this.$emit('positionInfo', this.model)
                this.model = {}
            }
        }
  }
</script>